using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject EnemyProjectile;
    public float speed;
    //Time between shots
    public float shootDelay;
    public float shootTimer;
    public float movetimer;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movetimer = 3;
        anim = GetComponent<Animator>();
        shootDelay = 3;
        shootTimer = 1;
        speed = 0f;
        rb = GetComponent<Rigidbody2D>();
        anim.SetTrigger("Start");
        //Play the appearing animation that moves the cow onto the screen
        rb.velocity = new Vector2(-500 * Time.deltaTime, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        movetimer = movetimer - Time.deltaTime;
        if(movetimer <= 0)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        rb.transform.Rotate(0, 0, (-speed/6) * Time.deltaTime);
        shootTimer = shootTimer - Time.deltaTime;

        //Fire Projectile when timer is zero
        if (shootTimer <= 0)
        {
            shootTimer = shootDelay;
            //Play shooting animation
            Instantiate(EnemyProjectile, transform.position, transform.rotation);
            
            //anim.SetTrigger("Shoot");
        }
    }

    //Destroy enemy upon being hit
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerProjectile")
        {
            speed = -2400f;
            shootTimer = 500;
        }
        if (col.gameObject.tag == "Despawn")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}
