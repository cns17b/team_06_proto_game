using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{

    public float speed;
<<<<<<< HEAD
    private float health;
    private bool hasShield;
    private float ammo;
=======
<<<<<<< HEAD
<<<<<<< HEAD
    private float health;
    private bool hasShield;
    private float ammo;
=======
    public float invincibletimer;
    public int hit;
>>>>>>> a65085bbdc5f22ac9551dd335ae1847866af4b1b
=======
>>>>>>> parent of 4b25ee4... Stuff
>>>>>>> parent of 21a225d... Revert "no message"
    Rigidbody2D rb;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        ammo = 15;
        hasShield = false;
        health = 3;
=======
<<<<<<< HEAD
<<<<<<< HEAD
        ammo = 15;
        hasShield = false;
        health = 3;
=======
        hit = 0;
>>>>>>> a65085bbdc5f22ac9551dd335ae1847866af4b1b
=======
>>>>>>> parent of 4b25ee4... Stuff
>>>>>>> parent of 21a225d... Revert "no message"
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
<<<<<<< HEAD
        //End game if health is zero
        if (health == 0)
        {
            //play death animation
            Time.timeScale = 0;
        }
        //Add code to shoot when player presses space button if they have ammo
        //Add code to speed up and slow down with left and right
        //Add code to spawn ammo is the player does not have any ammo remaining for more than 15 seconds.
<<<<<<< HEAD
=======
=======

        if (move > 0)
        {
            //Debug.Log("pos");
            rb.velocity = new Vector2(rb.velocity.x, speed * move);
            anim.SetBool("isMoving", true);
        }
        else if (move < 0)
        {
            //Debug.Log("neg");
            rb.velocity = new Vector2(rb.velocity.x, speed * move);
            anim.SetBool("isMoving", true);
        }
        else if (move == 0)
        {
            anim.SetBool("isMoving", false);

        }
        if (hit == 3)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            anim.SetBool("Dead", true);
            if (invincibletimer <= 0)
            {
                endgame();
            }
        } 
        //Fire Projectile is Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("shoot");
            shoot();
        }
>>>>>>> a65085bbdc5f22ac9551dd335ae1847866af4b1b
=======
>>>>>>> parent of 4b25ee4... Stuff
>>>>>>> parent of 21a225d... Revert "no message"
    }

    void OnTriggerEnter2D(Collider2D col)
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 21a225d... Revert "no message"
        //Play hit sound and move back if hit by meteor or projectile
=======
        //Play hit sound and move back
>>>>>>> parent of 4b25ee4... Stuff
        if (col.gameObject.tag == "Meteor")
        {
            transform.Translate(0, 2, 0);
            audioData.Play(0);
        }
        //End game after 4 hits
        if (col.gameObject.tag == "Death")
        {
<<<<<<< HEAD
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
<<<<<<< HEAD
=======
=======
        if (invincibletimer <= 0)
        {
            //Play hit sound and hit animation
            if (col.gameObject.tag == "Meteor")
            {
                //Play Heath Loss animation (UI)
                hit = hit + 1;
                invincibletimer = 3;
                audioData.Play(0);
            }
            if (col.gameObject.tag == "Enemy")
            {
                //Play Heath Loss animation (UI)
                hit = hit + 1;
                invincibletimer = 3;
                audioData.Play(0);
            }
            if (col.gameObject.tag == "EnemyProjectile")
            {
                //Play Heath Loss animation (UI)
                hit = hit + 1;
                invincibletimer = 3;
                audioData.Play(0);
            }
        }
        if (hit == 1)
        {
            Destroy(health1);
=======
            Time.timeScale = 0;
            Destroy(this.gameObject);
            
>>>>>>> parent of 4b25ee4... Stuff
>>>>>>> parent of 21a225d... Revert "no message"
        }
    }
}
