using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    public string activeState = "";
    public bool dontDestroyOnLoad = true;
    
    Dictionary<string, State> states = new Dictionary<string, State>();
    private string currentActiveState = "";

    public State GetActiveState() {
        return states[currentActiveState];
    }

    public void Register(State state) {
        if (states.ContainsKey(state.stateName)) {
            Debug.LogError("Attempting to register a duplicate state name: " + state.stateName);
        } else {
            states[state.stateName] = state;
            state.stateMachine = this;
            Debug.Log("Regestering state: " + state.stateName);
        }
    }

    public void DeRegister(string name) {
        if (!states.ContainsKey(name)) {
            Debug.LogWarning("Deregistering a nonexisting state: " + name);
        } else {
            states.Remove(name);
            Debug.Log("DeRegestering state: " + name);

        }
    }

    public void ChangeState(string state) {
        if (state == "") {//no state is active; i.e. state machine is inactive
            if (states.ContainsKey(currentActiveState)) {
                states[currentActiveState].Exit();
            }
            activeState = state;
            Debug.Log("State machine is inactive");
            currentActiveState = activeState;
        } else if (states.ContainsKey(state)) {
            if (states.ContainsKey(currentActiveState)) {
                states[currentActiveState].Exit();
                Debug.Log("Deactivating state: " + currentActiveState);
            }
            activeState = state;
            Debug.Log("Activating state: " + activeState);
            currentActiveState = activeState;
            states[state].Enter();
        }
    }

    void Awake() {
        if (dontDestroyOnLoad) {
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update() {
        if (activeState != currentActiveState) {
            ChangeState(activeState);
        }
    }


}
