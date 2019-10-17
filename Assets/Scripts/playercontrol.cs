using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{

    public float speed;
    private float health;
    private bool hasShield;
    private float ammo;
    Rigidbody2D rb;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        ammo = 15;
        hasShield = false;
        health = 3;
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
        speed = 30f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, speed * move);
        //End game if health is zero
        if (health == 0)
        {
            //play death animation
            Time.timeScale = 0;
        }
        //Add code to shoot when player presses space button if they have ammo
        //Add code to speed up and slow down with left and right
        //Add code to spawn ammo is the player does not have any ammo remaining for more than 15 seconds.
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Play hit sound and move back if hit by meteor or projectile
        if (col.gameObject.tag == "Meteor")
        {
            if (hasShield == false)
            {
                transform.Translate(0, 2, 0);
                audioData.Play(0);
                health = health - 1;
                //play hit animation
                //Update heart display
            }
            else
            {
                hasShield = false;
                //stop shield animation
            }
        }

        // Give a shield if shield is picked up
        if (col.gameObject.tag == "shield")
        {
            hasShield = true;
            //Play shield animation
        }
        //Gain health if health is picked up (max 3)
        if (col.gameObject.tag == "health")
        {
            if (health < 3)
            {
                health = health + 1;
                //Update heart display
            }
        }

        //Gain ammo is ammo is picked up (max 15)
        if (col.gameObject.tag == "ammo")
        {
            ammo = 15;
            //Update UI.
        }
    }

    
}
