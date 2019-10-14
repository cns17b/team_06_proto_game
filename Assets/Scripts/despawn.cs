using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class despawn : MonoBehaviour
{
    public int count;
    public Text countText;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        countText.text = "Score: " + count.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Meteor")
        {
            count = count + 1;
            countText.text = "Score: " + count.ToString();
        }

    }
}
