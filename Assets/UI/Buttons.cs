using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

    StateMachine sm;

    private void Start() {
        sm = FindObjectOfType<StateMachine>();
    }

    public void RestartLevel() {
        if (sm) {
            sm.ForceTransition("StartLevel");
        }
    }

    public void NextLevel() {
        if (sm) {
            FindObjectOfType<GameManager>().currentLevel = FindObjectOfType<GameManager>().nextLevel;
            sm.ForceTransition("EndLevel");
        }
    }

    public void ProgressMap() {
        if (sm) {
            sm.ForceTransition("ProgressMap");
        }
    }

}
