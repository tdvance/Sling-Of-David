using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Events;
using System;
/// <summary>
/// Unlike the UI button, is in world space with a transform, not a canvas space with a rect transform.
/// </summary>
[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class FancyButton : MonoBehaviour {
    public Sprite normalSprite;
    public Color normalColor;
    public float normalScale = 1f;

    public Sprite hoverSprite;
    public Color hoverColor;
    public float hoverScale = 1.25f;
    public TextMesh hoverText;

    public Sprite pressedSprite;
    public Color pressedColor;
    public float pressedScale = 1.3f;

    public Sprite disabledSprite;
    public Color disabledColor;
    public float disabledScale = .9f;

    public bool buttonEnabled = true;

    [Serializable]
    public class ClickEvent : UnityEvent { }
        
    public ClickEvent OnClick;

    private bool hovering = false;
    private bool pressed = false;
    private bool wasPressed = false;

    private float hoverTextSize = 0;

    private SpriteRenderer sr;
    // Use this for initialization
    void Start() {
        if (!hoverText) {
            hoverText = GetComponentInChildren<TextMesh>();
        }
        if (hoverText) {
            hoverTextSize = hoverText.characterSize;
            hoverText.characterSize = 0;
        }

        if (!hoverSprite) {
            hoverSprite = normalSprite;
        }

        if (!pressedSprite) {
            pressedSprite = hoverSprite;
        }

        if (!disabledSprite) {
            disabledSprite = pressedSprite;
        }
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        pressed = hovering && CrossPlatformInputManager.GetButtonDown("Fire1");
        if (pressed && enabled) {
            wasPressed = true;
        }
        if (!hovering) {
            wasPressed = false;
        }
        SetButtonState();
        //if clicked
        if (wasPressed && CrossPlatformInputManager.GetButtonUp("Fire1")) {
            if (enabled) {
                OnClick.Invoke();
            }
            wasPressed = false;
        }
    }

    public void Test(string arg) {
        Debug.Log("Clicked for " + arg);
    }

    void SetButtonState() {
        if (hoverText) {
            hoverText.characterSize = 0;
        }
        if (buttonEnabled) {           
            if (pressed) {
                sr.sprite = pressedSprite;
                sr.color = pressedColor;
                transform.localScale = new Vector3(pressedScale, pressedScale, 1);
            } else if (hovering) {
                hoverText.characterSize = hoverTextSize;
                sr.sprite = hoverSprite;
                sr.color = hoverColor;
                transform.localScale = new Vector3(hoverScale, hoverScale, 1);

            } else {
                sr.sprite = normalSprite;
                sr.color = normalColor;
                transform.localScale = new Vector3(normalScale, normalScale, 1);

            }
        } else {
            sr.sprite = disabledSprite;
            sr.color = disabledColor;
            transform.localScale = new Vector3(disabledScale, disabledScale, 1);
            wasPressed = false;
        }
    }
    private void OnMouseEnter() {
        hovering = true;
    }

    private void OnMouseExit() {
        hovering = false;
    }



}