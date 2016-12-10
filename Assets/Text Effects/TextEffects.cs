using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEffects : MonoBehaviour {

    TextMesh tm;

    float csizeM = 0;
    float csizeB = 0;
    float csizeMaxT = 0;

    float alphaM = 0;
    float alphaB = 0;
    float alphaMaxT = 0;


    // Use this for initialization
    void Start() {
        tm = GetComponent<TextMesh>();
        //test:
        //ChangeSize(5, 5);
        //ChangeAlpha(0, 5);
        //Destroy(5);
    }

    // Update is called once per frame
    void Update() {
        //smoothly change size
        if (csizeMaxT > 0) {
            if (Time.time >= csizeMaxT) {
                tm.characterSize = csizeM * csizeMaxT + csizeB;
                csizeMaxT = 0;
            } else {
                tm.characterSize = csizeM * Time.time + csizeB;
            }
        }

        //smoothly change alpha
        if (alphaMaxT > 0) {
            if (Time.time >= alphaMaxT) {
                Color c = tm.color;
                tm.color = new Color(c.r, c.g, c.b, alphaM * alphaMaxT + alphaB);
                alphaMaxT = 0;
            } else {
                Color c = tm.color;
                tm.color = new Color(c.r, c.g, c.b, alphaM * Time.time + alphaB);
            }
        }
    }

    public void Destroy(float time = 0f) {
        Destroy(gameObject, time);
    }

    public void ChangeSize(float toCharacterSize, float time = 0f) {
        if (time <= 0) {
            tm.characterSize = toCharacterSize;
        } else {
            //set up linear size change over time
            float t0 = Time.time;
            float t1 = t0 + time;
            float s = tm.characterSize;
            csizeM = (toCharacterSize - s) / (t1 - t0);
            csizeB = s - csizeM * t0;
            csizeMaxT = t1;
        }
    }

    public void ChangeAlpha(float toAlpha, float time = 0f) {
        if (time <= 0) {
            Color c = tm.color;
            tm.color = new Color(c.r, c.g, c.b, toAlpha);
        } else {
            //set up linear size change over time
            float t0 = Time.time;
            float t1 = t0 + time;
            float s = tm.color.a;
            alphaM = (toAlpha - s) / (t1 - t0);
            alphaB = s - alphaM * t0;
            alphaMaxT = t1;
        }
    }

}
