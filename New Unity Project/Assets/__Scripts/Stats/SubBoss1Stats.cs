using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubBoss1Stats : EnemyStats
{
    public GameObject portal;

    public override void Die()
	{
		base.Die();

        if (isAlive)
        {
            // give player xp for the kill
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            playerStats.IncreaseXp(15);

            // play the death animation and start the next scene
            StartCoroutine(PlayDeathAnim());
            
            // code to give the player the SubBoss powerUp

            // update the isAlive variable
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

        // instatiate the portal
        CreatePortal();
    }

    void CreatePortal()
    {
        GameObject go = Instantiate(portal);
        go.transform.position = transform.position;
    }
}
