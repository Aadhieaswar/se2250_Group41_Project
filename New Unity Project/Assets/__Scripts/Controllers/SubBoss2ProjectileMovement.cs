using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBoss2ProjectileMovement : SubBossProjectileMovement //a subclass
{
    void Start()
    {
        FindShooter();
    }

    void Update()
    {
        Move();
    }

    //Override subboss projectile movement to search for subboss2 instead of subboss
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
