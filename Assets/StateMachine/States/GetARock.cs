using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetARock : MonoBehaviour {
    GameManager gm;
    public void OnEnterState(State state) {
        Debug.Log("Entering state: " + state.stateName);
        Sling sling = FindObjectOfType<Sling>();
        MiniInventory inventory = FindObjectOfType<MiniInventory>();

        if (inventory.Empty()) {
            state.TriggerTransition(2); //Empty Sling
        } else {
            sling.GetARock(inventory);
            state.TriggerTransition(0); //Sling With Rock
        }
        gm = FindObjectOfType<GameManager>();
        if (gm.CountEnemies() == 0) {
            gm.UnlockNextLevel();
        }
    }


    public void OnExitState(State state) {
        Debug.Log("Exiting state: " + state.stateName);

    }

    public void OnUpdateState(State state) {
        if (gm.numberOfEnemies == 0) {
            gm.UnlockNextLevel();
        }
        //Debug.Log("Updating state: " + state.stateName);
    }

    public void OnFixedUpdateState(State state) {
        //Debug.Log("(Fixed) Updating state: " + state.stateName);

    }
}
