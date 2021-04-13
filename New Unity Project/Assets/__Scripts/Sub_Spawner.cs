using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnedObject;

    public int killsNeeded = 2; 

    public static int killCount = 0;

    private void Spawn(){
        GameObject go = Instantiate(spawnedObject, transform.position, transform.rotation);
        go.name = "SubBoss";
    }

    // Update is called once per frame
    void Update()
    {
        //spawns the subboss once 2 henchman have been killed
        if (killCount == killsNeeded)
        {
            Spawn();
            killCount++;
        }
    }
}
