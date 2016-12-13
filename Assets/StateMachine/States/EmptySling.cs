using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySling : MonoBehaviour {
    public void OnEnterState(State state) {
        Debug.Log("Entering state: " + state.stateName);
        FindObjectOfType<Sling>().GetComponent<Dragable>().enabled = false;
        if (FindObjectOfType<GameManager>().CountEnemies() == 0) {
            FindObjectOfType<GameManager>().UnlockNextLevel();
        }
    }

    public void OnExitState(State state) {
        Debug.Log("Exiting state: " + state.stateName);
    }

    public void OnUpdateState(State state) {
        //Debug.Log("Updating state: " + state.stateName);
    }

    public void OnFixedUpdateState(State state) {
        //Debug.Log("(Fixed) Updating state: " + state.stateName);
    }
}
