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
            TakeDamage(damage.GetValue());
        }

        if (other.gameObject.CompareTag("Melee"))
        {
            TakeDamage(damage.GetValue() / 2);
        }
    }
}
