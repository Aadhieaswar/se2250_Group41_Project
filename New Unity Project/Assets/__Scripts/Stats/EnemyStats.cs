using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : CharacterStats
{
    [Header("Set in Inspector")]
    public GameObject healthBarGo;
    public Canvas canvas;

    // set dynamically
    [HideInInspector]
    public bool isAlive;

    GameObject bar;

    public virtual void OnHit()
    {
        // method to be called before the characters take damage incase to add animations and the such
    }

    private void Start()
    {
        bar = Instantiate(healthBarGo);
        bar.transform.SetParent(canvas.transform, false);
        bar.transform.localPosition = new Vector3(0, 0, 0);

        healthBar = bar.GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

        isAlive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Stat damage = PlayerManager.instance.player.GetComponent<PlayerStats>().damage;

        if (other.gameObject.CompareTag("Bullet"))
        {
            OnHit();
            TakeDamage(damage.GetValue());
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Melee"))
        {
            OnHit();
            TakeDamage(damage.GetValue() / 2);
        }

        if (other.gameObject.CompareTag("SubBossAttack") && !(gameObject.CompareTag("SubBoss"))) {
            OnHit();
            TakeDamage(75);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SubBoss2Attack") && !(gameObject.CompareTag("SubBoss2"))) {
            OnHit();
            TakeDamage(100);
            Destroy(other.gameObject);
        }
    }

}
