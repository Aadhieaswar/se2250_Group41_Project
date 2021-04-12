using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossStats : EnemyStats
{
    public override void Die()
    {
        base.Die();

        if (isAlive)
        {
            // give player XP
            PlayerStats stats = PlayerManager.instance.GetComponent<PlayerStats>();
            stats.IncreaseXp(30);

            // play death animation
            StartCoroutine(PlayDeathAnim());

            // update isAlive variable
            isAlive = false;
        }
    }

    IEnumerator PlayDeathAnim()
    {
        // trigger the death animation
        this.GetComponent<Animator>().SetTrigger("Die");

        // wait for the animation to end
        yield return new WaitForSeconds(3);

        // destroy the game object
        Destroy(gameObject, 1f);

        // Show win message / window
    }
}
