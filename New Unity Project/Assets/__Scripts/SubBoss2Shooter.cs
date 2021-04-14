using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBoss2Shooter : SubBossShooter //a subclass for the second boss
{
    void Update()
    {
        //Same method as throw projectile from subBossShooter
        ThrowProjectile();
    }
}
