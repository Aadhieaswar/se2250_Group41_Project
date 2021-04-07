using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [Header("Set in Inspector")]
    public GameObject healthBarGo;
    public Canvas canvas;

    GameObject bar;
    bool _isAlive;

    private void Start()
    {
        bar = Instantiate(healthBarGo);
        bar.transform.SetParent(canvas.transform, false);
        bar.transform.localPosition = new Vector3(0, 0, 0);

        healthBar = bar.GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

        _isAlive = true;
    }

    public override void Die()
	{
		base.Die();

        if (_isAlive)
        {
            // give player xp for the kill
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            playerStats.IncreaseXp(15);

            // play death animation
            this.GetComponent<Animator>().SetBool("IsDead", true);

            // code to give the player the SubBoss powerUp

            // update the _isAlive variable
            _isAlive = false;
        }


        StartCoroutine(LoadNext());
	}

    IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(4f);
        PlayerManager.instance.Unload("Level1");
        PlayerManager.instance.LoadLevel("Level2");
    }

    private void OnTriggerEnter(Collider other)
    {
        Stat damage = PlayerManager.instance.player.GetComponent<PlayerStats>().damage;

        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(damage.GetValue());
        }

        if (other.gameObject.CompareTag("Melee"))
        {
            TakeDamage(damage.GetValue() / 2);
        }
    }
}
