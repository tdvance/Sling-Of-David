using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


/// <summary>
/// Allow user to select a level by pressing a button.
/// </summary>
public class LevelSelector : MonoBehaviour {
    public GameObject levelsHolder;


    private void Start() {
        foreach(Transform t in levelsHolder.transform) {
            FancyButton b = t.gameObject.GetComponent<FancyButton>();
            //TODO enable unlocked levels
        }
    }

    public void Select(string level) {
        FindObjectOfType<GameManager>().currentLevel = level;
        FindObjectOfType<StateMachine>().GetActiveState().TriggerTransition(0);
    }


    public void ForceTransition(string state) {
        FindObjectOfType<StateMachine>().activeState = state;

    }

}
