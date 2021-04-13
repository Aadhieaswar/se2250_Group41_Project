using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBossStats : EnemyStats
{
    public override void Die()
    {
        base.Die();

        if (isAlive)
        {
            // give player XP
            PlayerStats stats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            stats.IncreaseXp(30);

            // play death animation
            StartCoroutine(PlayDeathAnim());

            // update isAlive variable
            isAlive = false;
        }
    }

    public override void OnHit()
    {
        base.OnHit();

        StartCoroutine(PlayHitAnimation());
    }

    IEnumerator PlayHitAnimation()
    {
        this.GetComponent<NavMeshAgent>().isStopped = true;
        this.GetComponent<Animator>().SetTrigger("TakeHit");

        yield return new WaitForSeconds(2f);

        this.GetComponent<NavMeshAgent>().isStopped = false;
        float distance = Vector3.Distance(PlayerManager.instance.player.transform.position, transform.position);
        this.GetComponent<Animator>().SetFloat("Distance", distance);
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
