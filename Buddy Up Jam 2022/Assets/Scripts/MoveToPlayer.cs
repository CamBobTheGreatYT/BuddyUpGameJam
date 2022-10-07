using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour {

    public Rigidbody2D player;
    public Rigidbody2D rb;
    public bool aggro = false;
    public float Speed = 0.0025f;
    public float Direction = 0.0f;
    public double health = 10.0;
    public float x = 0;
    public float y = 0;
    
    public PlayerMovement PlayerMovement;

    void Update() {
        Vector2 Direction = rb.position - player.position;
        Direction.Normalize();
        if (aggro) {
            rb.position -= (Direction * Speed);
            transform.up = player.transform.position - transform.position;
            if (health <= 0) this.gameObject.SetActive(false);
        }
        else {
            x = rb.position.x;
            y = rb.position.y;
            rb.position = new Vector2(x,y);
            rb.rotation = 90;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        aggro = true;

        if (collision.gameObject.tag == "weapon" && Input.GetKey("space")) health -= 5;

    }
    void OnTriggerExit2D(Collider2D collision) {
        aggro = false;
    }

}