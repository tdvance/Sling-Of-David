using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/// <summary>
/// Attach this script to a sprite having a Collider2D component to make it draggable.
/// </summary>
public class Dragable : MonoBehaviour {

    [Tooltip("Cross Platform Input Manager buttion for dragging the sprite")]
    public string dragButton = "Fire1";

    [Tooltip("Probably should keep this set to true")]
    public bool mouseMustBeOver = true;

    [Tooltip("Object used for callbacks; optional")]
    public MonoBehaviour userDragHandlerObject;
    public string callbackWhenDraggingStarts = "None";
    public string callbackWhenDraggingEnds = "None";
    [Tooltip("This one takes a Vector3 value that is fed the drag amount this tick when called")]
    public string dragImpulseCallback = "None";

    [Tooltip("A script can set this to false if attempting to drop in an illegal location")]
    public bool allowDrop = true;

    bool isBeingDragged = false;
    bool mouseIsOver = false;
    Vector3 dragStart = Vector3.zero;
    Vector3 positionLastUpdate = Vector3.zero;
    Vector3 originalPosition = Vector3.zero;


    // Use this for initialization
    void Start() {
        isBeingDragged = false;
        if (mouseMustBeOver && !GetComponent<Collider>() && !GetComponent<Collider2D>()) {
            Debug.LogError("Detection of mouseover requires a Collider or Collider2D component");
        }
    }

    // Update is called once per frame
    void Update() {
        if (isBeingDragged && !CrossPlatformInputManager.GetButton(dragButton)) {
            StopDragging();
        }
        if (!isBeingDragged && MouseIsOver() && CrossPlatformInputManager.GetButton(dragButton)) {
            StartDragging();
        }
        if (isBeingDragged) {
            Drag();
        }
    }

    void StopDragging() {
        Debug.Log("Stop Dragging " + gameObject);
        isBeingDragged = false;
        if (userDragHandlerObject && callbackWhenDraggingEnds != "None") {
            userDragHandlerObject.Invoke(callbackWhenDraggingEnds, 0f);
        }
        if (!allowDrop) {
            RevertPosition();
        }
    }

    void RevertPosition() {
        //TODO animate this
        transform.position = originalPosition;
    }

    void StartDragging() {
        Debug.Log("Start Dragging " + gameObject);
        dragStart = Camera.main.ScreenToWorldPoint(CrossPlatformInputManager.mousePosition) - transform.position;
        positionLastUpdate = dragStart;
        originalPosition = transform.position;
        isBeingDragged = true;
        if (userDragHandlerObject && callbackWhenDraggingStarts != "None") {
            userDragHandlerObject.Invoke(callbackWhenDraggingStarts, 0f);
        }
    }

    void Drag() {
        Vector3 v = Camera.main.ScreenToWorldPoint(CrossPlatformInputManager.mousePosition) - dragStart;
        transform.position = v;
        if (userDragHandlerObject && dragImpulseCallback != "None") {
            Vector3 impulse = v - positionLastUpdate;
            userDragHandlerObject.StartCoroutine(dragImpulseCallback, impulse);
        }

        positionLastUpdate = v;
    }

    private void OnMouseEnter() {
        mouseIsOver = true;
    }

    private void OnMouseExit() {
        mouseIsOver = false;
    }

    bool MouseIsOver() {
        if (!mouseMustBeOver) {
            return true;
        }

        return mouseIsOver;
    }
}
