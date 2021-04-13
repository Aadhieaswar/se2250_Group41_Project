using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBoss2ProjectileMovement : SubBossProjectileMovement
{
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("SubBoss").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
