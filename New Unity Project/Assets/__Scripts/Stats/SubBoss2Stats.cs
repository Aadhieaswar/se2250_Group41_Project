using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubBoss2Stats : EnemyStats
{
    public GameObject portal;
    public GameObject message;

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
            PlayerPowerUp playerPowerUp = GameObject.Find("Hero").GetComponent<PlayerPowerUp>();
            playerPowerUp.SubBossTwoDefeated = true;

            // show message that player got the power up
            StartCoroutine(ShowMessage());

            // update variable
            isAlive = false;

            // update the objectives class
            ObjectivesForLevel.S.subBossAlive = false;
        }
    }

    IEnumerator ShowMessage()
    {
        GameObject playerUI = GameObject.Find("GameUI");

        yield return new WaitForSeconds(2f);

        GameObject go = Instantiate(message);
        go.transform.SetParent(playerUI.transform, false);
        go.transform.localPosition = new Vector3(0, 0, 0);

        Destroy(go, 4f);
    }

    IEnumerator PlayDeathAnim()
    {
        // trigger the death animation
        this.GetComponent<Animator>().SetTrigger("Die");

        // wait for the animation to end
        yield return new WaitForSeconds(2.5f);

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
