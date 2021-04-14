using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Sub_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnedObject;
    public HenchmanStats henchmanStats;

    public int killsNeeded = 2; 

    public static int killCount = 0;

    private void Spawn(){
        GameObject go = Instantiate(spawnedObject, transform.position, transform.rotation);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            go.name = "SubBoss";
        }
        else {
            go.name = "SubBoss2";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawns the subboss once 2 henchman have been killed
        if (killCount == killsNeeded)
        {
            Spawn();
            //resets the kill count for the next level
            killCount = 0;
            if (henchmanStats != null)
            {
                henchmanStats.maxHealth += 100;
            }
        }
    }
}
