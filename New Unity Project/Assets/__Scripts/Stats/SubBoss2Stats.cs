using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubBoss2Stats : EnemyStats
{
    public override void Die()
    {
        base.Die();

        if (isAlive)
        {
            // give player XP for the kill
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            playerStats.IncreaseXp(20);

            // play death animation and move to next scene
            StartCoroutine(PlayDeathAnim());

            // give the player the subBoss power

            // update variable
            isAlive = false;

        }
    }

    IEnumerator PlayDeathAnim()
    {
        // trigger the death animation
        this.GetComponent<Animator>().SetTrigger("Die");

        // wait for the animation to end
        yield return new WaitForSeconds(2.5f);

        // destroy the game object
        Destroy(gameObject);

        // wait for the object to be destroyed
        yield return new WaitForSeconds(1);

        // move to the next scene
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
