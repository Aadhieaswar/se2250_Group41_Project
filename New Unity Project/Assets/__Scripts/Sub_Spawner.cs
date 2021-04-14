using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnedObject;
    public HenchmanStats henchmanStats;

    public int killsNeeded = 2; 
    public static int killCount = 0;

    private void Spawn(){ //spawns the subboss
        GameObject go = Instantiate(spawnedObject, transform.position, transform.rotation);
        go.name = "SubBoss";
    }

    // Update is called once per frame
    void Update()
    {
        //spawns the subboss once the required number henchman have been killed
        if (killCount == killsNeeded)
        {
            Spawn();
            //resets the kill count for the next level
            killCount = 0;
            //increases the health of henchman as you progress through levels
            henchmanStats.maxHealth += 100;
        }
    }
}
