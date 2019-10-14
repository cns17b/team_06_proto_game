using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meteormove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Animator anim;
    public int count;
    public Text countText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countText.text = "Score: " + count.ToString();
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
            end();
            count = count + 1;
            countText.text = "Score: " + count.ToString();
        }

        if (col.gameObject.tag == "Player")
        {
            end();
        }
        if (col.gameObject.tag == "PlayerProjectile")
        {
            speed = 0;
            count = count + 1;
            countText.text = "Score: " + count.ToString();
            anim.SetBool("ifCrash", true);
        }
    }
    void end()
    {
        
        Destroy(this.gameObject);
    }

}