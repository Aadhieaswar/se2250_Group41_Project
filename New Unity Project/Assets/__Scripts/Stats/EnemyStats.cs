using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            print("died");

            // give player xp for the kill
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            playerStats.IncreaseXp(15);

            // start the next scene
            StartCoroutine(PlayDeathAnim());
            
            // code to give the player the SubBoss powerUp

            // update the _isAlive variable
            _isAlive = false;

        }
	}

    IEnumerator PlayDeathAnim()
    {
        this.GetComponent<Animator>().SetTrigger("Die");

        yield return new WaitForSeconds(3);

        Destroy(gameObject, 1f);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
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
