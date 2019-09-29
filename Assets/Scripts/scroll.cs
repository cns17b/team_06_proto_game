using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(speed * Time.time, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset; 
    }
}
