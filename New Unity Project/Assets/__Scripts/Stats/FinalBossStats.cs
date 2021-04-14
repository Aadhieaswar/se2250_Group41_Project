using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalBossStats : EnemyStats
{
    public GameObject message;

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

            // Show win message / window
            StartCoroutine(ShowMessage());

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
    }

    IEnumerator ShowMessage()
    {
        GameObject playerUI = GameObject.Find("GameUI");

        // wait for 2 seconds
        yield return new WaitForSeconds(4f);

        // show the win message
        GameObject go = Instantiate(message);
        go.transform.SetParent(playerUI.transform, false);
        go.transform.localPosition = new Vector3(0, 0, 0);
    }
}
