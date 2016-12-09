using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceivesDamage : MonoBehaviour {
    public float health = 100f;
    public float valuePerDamageReceived = 1f;
    public float damageExponent = 1.5f;
    public float killingY = -20f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y < killingY) {
            ReceiveDamage(health);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject obj = collision.gameObject;
        DoesDamage dd = obj.GetComponent<DoesDamage>();
        if (dd) {
            Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
            Vector3 velocity = objRb.velocity - rb.velocity;
            //Debug.Log("Velocity: " + velocity.magnitude);
            float damage = dd.vDamage * Mathf.Pow(velocity.magnitude * dd.vDamageMultiplier, dd.vDamageExponent);
            ReceiveDamage(damage);
        }
    }

    void ReceiveDamage(float amount) {
        float damage = Mathf.Min(health, amount);
        float score = Mathf.Pow(damage * valuePerDamageReceived, damageExponent);
        Score(score);
        health -= damage;
        Debug.Log("Damage: " + amount + "; health: " + health);
        if (health <= 0) {
            Die();
        }
    }
    void Score(float amount) {
        Debug.Log("Score += " + amount);
        //TODO
    }

    void Die() {
        //TODO
        Destroy(gameObject);
    }
}
