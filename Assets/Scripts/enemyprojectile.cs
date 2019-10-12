using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectile : MonoBehaviour
{
    public class playerprojectile : MonoBehaviour
    {
        Rigidbody2D rb;
        public float speed;

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

        //Play Hit animation and despawn at hit
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                //PLAY EXPLOSION
                Destroy(this.gameObject);
            }
            if (col.gameObject.tag == "Despawn")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
