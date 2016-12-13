using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ProgressMap : MonoBehaviour {


    public void OnEnterState(State state) {
        Debug.Log("Entering state: " + state.stateName);
        SceneManager.LoadScene("Progress");
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
