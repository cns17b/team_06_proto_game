using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public GameObject PlayerProjectile;
    public float speed;
    public int health;
    Rigidbody2D rb;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
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
        //Play Idle animation, and moving animation if moving
        float move = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, speed * move);
        if (health == 0)
        {
            //PLAY DEATH ANIMATION
        }
        //Fire Projectile is Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Play Shooting Animation
            Instantiate(PlayerProjectile, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Play hit sound and hit animation
        if (col.gameObject.tag == "Meteor")
        {
            //Play Heath Loss animation (UI)
            health = health - 1;
            audioData.Play(0);
        }
        if (col.gameObject.tag == "Enemy")
        {
            //Play Heath Loss animation (UI)
            health = health - 1;
            audioData.Play(0);
        }
        if (col.gameObject.tag == "EnemyProjectile")
        {
            //Play Heath Loss animation (UI)
            health = health - 1;
            audioData.Play(0);
        }


    }
    void endgame()
    {
        //Ends game when health is zero.  PLAY DEATH ANIMATION
        Time.timeScale = 0;
        Destroy(this.gameObject);

    }
}
