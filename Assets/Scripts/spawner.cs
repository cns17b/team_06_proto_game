using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //An individual meteor being spawned at a time
    public GameObject meteorOne;
    public GameObject meteorTwo;
    public GameObject meteorThree;

    //Determines which meteor spawns
    public int spawnWhich;
    //Determines if one, two, or three meteors spawn
    public int spawnNum;
    //Timing between spawns
    public float spawnDelay;
    public float spawnTimer;

    //Possible Spawning Heights
    public float Ymin;
    public float Ymax;

    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = 2;
        spawnTimer = 2;
        Ymin = -12;
        Ymax = 18;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update time between spawns
        spawnTimer = spawnTimer - Time.deltaTime;
        if (spawnTimer <= 0)
        {
            //Spawn
            spawnMeteor();
            //Reset spawn delay
            spawnTimer = spawnDelay;
        }
    }

    void spawnMeteor()
    {
        //Determine how many meteors spawn
        spawnNum = Random.Range(1, 6);
        for (int i = 0; i < spawnNum; i++)
        {
            //Determine meteor's Y position (X position is fixed at 40 for each spawn)
            Vector2 position = new Vector2(40, Random.Range(Ymin, Ymax));
            //Determine which meteor to spawn
            spawnWhich = Random.Range(1, 4);
            if(spawnWhich == 1)
            {
                Instantiate(meteorOne, position, transform.rotation);
            }
            if (spawnWhich == 2)
            {
                Instantiate(meteorTwo, position, transform.rotation);
            }
            if (spawnWhich == 3)
            {
                Instantiate(meteorThree, position, transform.rotation);
            }

        }
    }
}
