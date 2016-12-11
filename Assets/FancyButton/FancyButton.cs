using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class FancyButton : MonoBehaviour {
    public Sprite normalSprite;
    public Color normalColor;
    public float normalScale = 1f;

    public Sprite hoverSprite;
    public Color hoverColor;
    public float hoverScale = 1.25f;

    public Sprite pressedSprite;
    public Color pressedColor;
    public float pressedScale = 1.3f;

    public Sprite disabledSprite;
    public Color disabledColor;
    public float disabledScale = .9f;

    public bool buttonEnabled = true;

    private bool hovering = false;
    private bool pressed = false;


    private SpriteRenderer sr;
    // Use this for initialization
    void Start() {
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
        pressed = hovering && CrossPlatformInputManager.GetButton("Fire1");
        SetButtonState();
    }

    void SetButtonState() {
        if (buttonEnabled) {
            if (pressed) {
                sr.sprite = pressedSprite;
                sr.color = pressedColor;
                transform.localScale = new Vector3(pressedScale, pressedScale, 1);
            } else if (hovering) {
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
        }
    }
    private void OnMouseEnter() {
        hovering = true;
    }

    private void OnMouseExit() {
        hovering = false;
    }



}