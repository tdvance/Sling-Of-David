using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockDeployed : MonoBehaviour {
    GameManager gm;
    public void OnEnterState(State state) {
        Debug.Log("Entering state: " + state.stateName);
        GameObject.Find("Restart Level").GetComponent<Button>().interactable = true;
        gm = FindObjectOfType<GameManager>();
        if (gm.CountEnemies() == 0) {
            gm.UnlockNextLevel();
        }
    }

    public void OnExitState(State state) {
        Debug.Log("Exiting state: " + state.stateName);

    }

    public void OnUpdateState(State state) {
        //Debug.Log("Updating state: " + state.stateName);
        if (gm.numberOfEnemies == 0) {
            gm.UnlockNextLevel();
        }
    }

    public void OnFixedUpdateState(State state) {
        //Debug.Log("(Fixed) Updating state: " + state.stateName);

    }
}
