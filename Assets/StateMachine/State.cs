using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public string stateName;
    public MonoBehaviour stateCallbackClass;
    public string EnterStateCallback;
    public string ExitStateCallback;
    public string stateUpdateCallback;
    public string stateFixedUpdateCallback;
    public StateMachine stateMachine;

    public string timedTransitionTo;
    public float timeForTransition;

    public string[] triggeredTransitionTo;

    [Tooltip("Setting to true will make state active, but state machine will not know about it.")]
    public bool active;

    private string currentName = "";


    // Use this for initialization
    void Start() {
        if (!stateMachine) {
            stateMachine = FindObjectOfType<StateMachine>();
        }
        if (stateName.Length == 0) {
            stateName = gameObject.name;
        }
        active = false;
    }

    public void TriggerTransition(int which = 0) {
        if (active) {
            stateMachine.activeState = triggeredTransitionTo[which];
        }
    }

    public void Enter() {
        active = true;
        stateCallbackClass.StartCoroutine(EnterStateCallback, this);
        if (timeForTransition > 0 && timedTransitionTo.Length > 0) {
            Invoke("DoTimedTransition", timeForTransition);
        }
    }

    void DoTimedTransition() {
        stateMachine.activeState = timedTransitionTo;
    }


    public void Exit() {
        CancelInvoke();
        stateCallbackClass.StartCoroutine(ExitStateCallback, this);
        active = false;
    }

    // Update is called once per frame
    void Update() {
        if (currentName != stateName) {
            ChangeName(currentName, stateName);
        }
        if (active) {
            stateCallbackClass.StartCoroutine(stateUpdateCallback, this);
        }
    }

    void FixedUpdate() {
        if (active) {
            stateCallbackClass.StartCoroutine(stateFixedUpdateCallback, this);
        }
    }

    void ChangeName(string f, string t) {
        if (stateMachine) {
            stateMachine.DeRegister(f);
        } else {
            Debug.LogWarning("State is not part of any state machine");
        }
        stateName = t;
        currentName = t;
        if (stateMachine) {
            stateMachine.Register(this);
        }
    }

}
