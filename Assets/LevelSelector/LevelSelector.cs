using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


/// <summary>
/// Allow user to select a level by pressing a button.
/// </summary>
public class LevelSelector : MonoBehaviour {


    public void Select(int which=0) {
        FindObjectOfType<StateMachine>().GetActiveState().TriggerTransition(which);
    }


    public void ForceTransition(string state) {
        FindObjectOfType<StateMachine>().activeState = state;

    }

}
