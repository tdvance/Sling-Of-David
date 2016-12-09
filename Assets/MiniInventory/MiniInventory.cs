using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniInventory : MonoBehaviour {

    public GameObject[] initialInventory;

    [Tooltip("0 means compute from sizes of objects")]
    public float xSpacePerObject = 0;

    private Queue<GameObject> items = new Queue<GameObject>();

    // Use this for initialization
    void Start() {
        foreach (GameObject item in initialInventory) {
            items.Enqueue(item);
        }
        UpdateDisplay();
    }

    public int Count() {
        return items.Count;
    }

    public bool Empty() {
        return items.Count == 0;
    }

    public GameObject Get() {
        GameObject item = items.Dequeue();
        UpdateDisplay();
        return Instantiate(item);
    }

    public GameObject Get(Transform parent) {
        GameObject item = items.Dequeue();
        UpdateDisplay();
        return Instantiate(item, parent);
    }

    public GameObject Get(Transform parent, bool instantiateInWorldSpace) {
        GameObject item = items.Dequeue();
        UpdateDisplay();
        return Instantiate(item, parent, instantiateInWorldSpace);
    }

    public GameObject Get(Vector3 position) {
        GameObject item = items.Dequeue();
        UpdateDisplay();
        return Instantiate(item, position, Quaternion.identity);
    }

    public GameObject Get(Vector3 position, Quaternion rotation) {
        GameObject item = items.Dequeue();
        UpdateDisplay();
        return Instantiate(item, position, rotation);
    }

    public GameObject Get(Vector3 position, Transform parent) {
        GameObject item = items.Dequeue();
        UpdateDisplay();
        return Instantiate(item, position, Quaternion.identity, parent);
    }

    public GameObject Get(Vector3 position, Quaternion rotation, Transform parent) {
        GameObject item = items.Dequeue();
        UpdateDisplay();
        return Instantiate(item, position, rotation, parent);
    }

    void UpdateDisplay() {
        //clear out the old
        foreach (Transform t in transform) {
            Destroy(t.gameObject);
        }
        if (Empty()) {
            return;
        }
        float dx = xSpacePerObject;
        if (xSpacePerObject == 0) {
            foreach (GameObject item in items) {
                dx = Mathf.Max(dx, item.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * 2);
            }
        }
        float offset = transform.position.x - dx / 2 * Count();
        foreach (GameObject item in items) {
            GameObject g = Instantiate(item, new Vector3(offset, transform.position.y, transform.position.z), Quaternion.identity, transform);
            Rigidbody2D r = g.GetComponent<Rigidbody2D>();
            if (r) {
                r.simulated = false;
            }
            Collider2D c = g.GetComponent<Collider2D>();
            if (c) {
                c.enabled = false;
            }
            offset += dx;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
