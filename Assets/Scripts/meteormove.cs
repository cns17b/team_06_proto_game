using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteormove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Animator anim;
 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        speed = -1200f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        rb.transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    //Destroy Meteor at despawn collider
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Despawn")
        {
<<<<<<< HEAD
            end();
=======
            Debug.Log("true");
            anim.SetBool("ifCrash", true);
            Collide();
            
>>>>>>> origin/Random
        }

        if(col.gameObject.tag == "Player")
        {
<<<<<<< HEAD
            end();
        }
        if (col.gameObject.tag == "PlayerProjectile")
        {
            speed = 0;
            //Play Explosion
        }
    }
    void end()
=======
            Debug.Log("true");
            anim.SetBool("ifCrash", true);
            Collide();

        }
        if (col.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("true");
                anim.SetBool("ifCrash", true);
            Collide();
            //Play Explosion

        }
    }
    void Collide()
>>>>>>> origin/Random
    {
        Destroy(this.gameObject);
    }
}

   
