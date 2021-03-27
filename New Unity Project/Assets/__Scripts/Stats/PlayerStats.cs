using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public override void Die()
    {
        base.Die();

        // kill the player in some way
        PlayerManager.instance.KillPlayer();
    }
}
