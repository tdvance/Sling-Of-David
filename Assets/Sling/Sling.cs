using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour {

    public Vector3 rockOffset;
    public float forceMultiplier = 10f;
    public float minAngularVelocity = 100f;
    public float timescaleSpin = .5f;


    private Dragable dragable;
    private HingeJoint2D joint;

    private void Start() {
        joint = GetComponent<HingeJoint2D>();
        dragable = GetComponent<Dragable>();
        dragable.enabled = false;
    }

    
    // Update is called once per frame
    void Update() {

    }

    public bool HasRock() {
        return joint.connectedBody;
    }

    public bool GetARock(MiniInventory inventory) {
        if (HasRock()) {
            Debug.Log("Already has a rock");
            return false;
        }

        if (inventory.Empty()) {
            Debug.Log("Out of rocks");
            return false;
        }
        dragable.enabled = true;
        GameObject rock = inventory.Get(transform.position + rockOffset, transform);
        joint.autoConfigureConnectedAnchor = true;
        joint.connectedBody = rock.GetComponent<Rigidbody2D>();
        joint.autoConfigureConnectedAnchor = false;

        return true;
    }

    public void StartSlinging() {
        joint.connectedBody.gravityScale = 0;
        Time.timeScale = timescaleSpin;
        StateMachine sm = FindObjectOfType<StateMachine>();
        if (sm) {
            sm.activeState = "SlingSpinning";
        }
    }

    public void EndSlinging() {
        joint.connectedBody.gravityScale = 1;
        Time.timeScale = 1f;
        if (Mathf.Abs(joint.connectedBody.angularVelocity) < minAngularVelocity) {
            CancelSlinging();
        }else {
            ReleaseRock();
        }
    }

    public void ReleaseRock() {
        dragable.enabled = false;
        joint.connectedBody.transform.SetParent(null);
        joint.connectedBody = null;
        StateMachine sm = FindObjectOfType<StateMachine>();
        if (sm) {
            sm.activeState = "RockDeployed";
        }
    }

    public void CancelSlinging() {
        StateMachine sm = FindObjectOfType<StateMachine>();
        if (sm) {
            sm.activeState = "SlingWithRock";
        }
    }

    public void AddImpulse(Vector3 force) {
        //Debug.Log("Adding force: " + force);
        joint.connectedBody.AddTorque(-force.magnitude * forceMultiplier, ForceMode2D.Impulse);
    }

}
