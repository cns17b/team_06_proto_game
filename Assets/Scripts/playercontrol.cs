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
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
        speed = 30f;

        anim.SetBool("isMoving", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Play Idle animation, and moving animation if moving


        float move = Input.GetAxis("Vertical");

        if (move > 0)
        {
            Debug.Log("pos");
            rb.velocity = new Vector2(rb.velocity.x, speed * move);
            anim.SetBool("isMoving", true);
        }
        else if (move < 0)
        {
            Debug.Log("neg");
            rb.velocity = new Vector2(rb.velocity.x, speed * move);
            anim.SetBool("isMoving", true);
        }
        else if (move == 0)
        {
            anim.SetBool("isMoving", false);

        }
        if (health == 0)
        {
            anim.SetBool("Dead", true);
        }
        //Fire Projectile is Space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("shoot");
            shoot();
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
    void shoot()
    {
        Instantiate(PlayerProjectile, transform.position, transform.rotation);
    }
    void endgame()
    {
        //Ends game when health is zero.  PLAY DEATH ANIMATION
        Time.timeScale = 0;
        Destroy(this.gameObject);

    }
}
