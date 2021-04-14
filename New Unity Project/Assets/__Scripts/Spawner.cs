using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn(){ //spawns the henchmen in desired locations
        Instantiate(spawnedObject, transform.position, transform.rotation);
    }

}
