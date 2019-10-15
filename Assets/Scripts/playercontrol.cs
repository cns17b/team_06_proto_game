using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    public GameObject PlayerProjectile;
    public float speed;
    public float invincibletimer;
    public int hit;
    Rigidbody2D rb;
    AudioSource audioData;
    public Animator anim;
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    // Start is called before the first frame update
    void Start()
    {
        hit = 0;
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
        speed = 30f;
        invincibletimer = 0;

        anim.SetBool("isMoving", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Play Idle animation, and moving animation if moving
        invincibletimer = invincibletimer - Time.deltaTime;

        float move = Input.GetAxis("Vertical");

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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
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
        }
        if (hit == 2)
        {
            Destroy(health2);
        }
        if (hit == 3)
        {
            Destroy(health3);
        }

    }
    void shoot()
    {
        Instantiate(PlayerProjectile, transform.position, transform.rotation);
    }
    void endgame()
    {
      
       Time.timeScale = 0;
       Destroy(this.gameObject);
       

    }
}
