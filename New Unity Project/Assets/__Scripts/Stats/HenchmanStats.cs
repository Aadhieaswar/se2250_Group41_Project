using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenchmanStats : EnemyStats
{
    public GameObject heldHealer;
    private int random;

    AnimationStateController animationStateController;

    public override void InitializeStatus()
    {
        base.InitializeStatus();

        animationStateController = GetComponent<AnimationStateController>();

        random = Random.Range(0, 2);
    }

    public override void Die()
    {
        base.Die();

        // give the player XP points on death
        if (isAlive)
        {
            // give player xp for the kill
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            playerStats.IncreaseXp(5);

            //increase killounter
            Sub_Spawner.killCount++;

            // play the death animation
            animationStateController.HenchmanDeathAnim();

            // instantiate the healer (on condition)
            if (random == 1)
            {
                InstantiateHealer();
            }

            // update variable
            isAlive = false;
        }

        Destroy(gameObject, 3f);

    }

    private void InstantiateHealer()
    {
        heldHealer.transform.position = this.transform.position;
        Vector3 heldHealerPosition = heldHealer.transform.position;
        Instantiate(heldHealer, new Vector3(heldHealerPosition.x, heldHealerPosition.y + 3, heldHealerPosition.z), Quaternion.Euler(0f, 0f, 0f));
    }

}
