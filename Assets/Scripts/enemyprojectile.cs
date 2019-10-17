using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        speed = 1200f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
    }

    //Play Hit animation and despawn at hit
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            speed = 0;
            anim.SetTrigger("Hit");
            end();

        }
        if (col.gameObject.tag == "Despawn")
        {
            end();
        }
    }
    void end()
    {
        Destroy(this.gameObject);
    }
}
