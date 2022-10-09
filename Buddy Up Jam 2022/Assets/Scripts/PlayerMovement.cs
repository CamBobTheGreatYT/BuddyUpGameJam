using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{


    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float yrot = 0;
    public float xrot = 0;
    public double health = 20.0;
    public Rigidbody2D sword;
    public bool attack = false;
    public Rigidbody2D attackpos;
    public Rigidbody2D location;
    public GameObject winUI;
    Vector2 movement;
    

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0)
        {
            gameObject.transform.localScale = new Vector3(0.02f,0.02f,1f);
        }
        else if (movement.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-0.02f,0.02f,1f);
        }
        if (movement.x > 0)
        {
            sword.transform.localScale = new Vector3(189f,399f,1f);
        }
        else if (movement.x < 0)
        {
            sword.transform.localScale = new Vector3(-189f,399f,1f);
        }

        if (health <= 0) this.gameObject.SetActive(false);
        
        if (Input.GetKey("space")) {
            sword.rotation = -85;
            attack = true;
            sword.position = rb.position + attackpos.position;
        }
        else {
            sword.rotation = -10.5f;
            attack = false;
            sword.position = rb.position + location.position;
        }
        
    
    }
    
    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.rotation = 0;

    }

    void OnTriggerEnter2D (Collider2D collision) {

        if (collision.gameObject.tag == "enemyHitBox") health -= 5;

        if (collision.gameObject.tag == "Finish") {
            Debug.Log("Good Job");
            winUI.SetActive(true);
        }

    }


    
}