using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Program the movement of the player
public class Player_Controller : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardforce = 400f;
    public float sidewaysforce = 0.00001f;
    public float upwardsforce = 400f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardforce * Time.deltaTime);

        if (Input.GetKey("w"))
        {
            rb.AddForce(sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(-sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
