using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteormove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    private Animator anim;
 
    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("true");
            anim.SetBool("isCrashed", true);
            Destroy(this.gameObject);
        }

        if(col.gameObject.tag == "Player")
        {
            Debug.Log("true");
            anim.SetBool("isCrashed", true);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("true");
            anim.SetBool("isCrashed", true);
            //Play Explosion
            Destroy(this.gameObject);
        }
    }
}

   
