using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBoss2ProjectileMovement : SubBossProjectileMovement
{
    // Start is called before the first frame update
    void Start()
    {
        FindShooter();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void FindShooter() {
        if (GameObject.Find("SubBoss2") == null)
        {
            target = GameObject.Find("SpecialAttackShooter").transform;
        }
        else
        {
            target = GameObject.Find("SubBoss2").transform;
        }
    }
}
