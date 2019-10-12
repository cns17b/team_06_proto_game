using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    //An individual meteor being spawned at a time
    public GameObject meteorOne;
    public GameObject meteorTwo;
    public GameObject meteorThree;
    public GameObject enemy;

    //Determines which meteor spawns
    public int spawnWhich;
    //Determines if one, two, or three meteors spawn
    public int spawnNum;
    //Timing between spawns for meteors
    public float spawnDelayM;
    public float spawnTimerM;
    //Timing between spawns for enemies
    public float spawnDelayE;
    public float spawnTimerE;

    //Possible Spawning Heights
    public float Ymin;
    public float Ymax;

    // Start is called before the first frame update
    void Start()
    {
        spawnDelayM = 2;
        spawnTimerM = 2;
        spawnDelayE = 5;
        spawnTimerE = 5;
        Ymin = -12;
        Ymax = 15;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Update time between spawns
        spawnTimerM = spawnTimerM - Time.deltaTime;

        if (spawnTimerM <= 0)
        {
            //Spawn
            spawnMeteor();
            //Reset spawn delay
            spawnTimerM = spawnDelayM;
        }

        //Update time between spawns
        spawnTimerE = spawnTimerE - Time.deltaTime;

        if (spawnTimerE <= 0)
        {
            //Spawn
            spawnEnemy();
            //Reset spawn delay
            spawnTimerE = spawnDelayE;
        }
    }

    void spawnMeteor()
    {
        //Determine how many meteors spawn
        spawnNum = Random.Range(1, 6);
        for (int i = 0; i < spawnNum; i++)
        {
            //Determine meteor's Y position 
            Vector2 position = new Vector2(Random.Range(50,70), Random.Range(Ymin, Ymax));
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
    void spawnEnemy()
    {
        //Determine Enemie's Y position 
        Vector2 position = new Vector2(64, Random.Range(Ymin, Ymax));
        Instantiate(enemy, position, transform.rotation);
    }
}
