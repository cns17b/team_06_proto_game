using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Play hit sound and move back
        if (col.gameObject.tag == "Meteor")
        {
            transform.Translate(0, 2, 0);
            audioData.Play(0);
        }
        //End game after 4 hits
        if (col.gameObject.tag == "Death")
        {
            Time.timeScale = 0;
            Destroy(this.gameObject);
            
        }
    }
}
