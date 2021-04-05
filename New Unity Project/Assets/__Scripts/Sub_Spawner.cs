using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnedObject;
    public static int killCount = 0;

    private void Spawn(){
        Instantiate(spawnedObject, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //spawns the subboss once 2 henchman have been killed
        if(killCount == 2){
            Spawn();
            killCount++;
        }
    }
}
