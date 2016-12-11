using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


/// <summary>
/// Allow user to select a level by pressing a button.
/// </summary>
public class LevelSelector : MonoBehaviour {

    public int levelNumber;

    bool mouseOver = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (mouseOver && CrossPlatformInputManager.GetButtonDown("Fire1")) {
            Select();
        }
    }
    private void OnMouseEnter() {
        mouseOver = true;
        transform.localScale = new Vector3(1.25f, 1.25f, 1);
    }

    private void OnMouseExit() {
        mouseOver = false;
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void Select() {
        Debug.Log("Selected");
        FindObjectOfType<StateMachine>().GetActiveState().TriggerTransition(0);
    }

}
