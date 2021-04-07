using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // fields
    [Header("Set in Inspector")]
    public int maxHealth = 100;

    [Header("Set Dynamically")]
    public int currentHealth;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Henchman")) {
            playerStats.TakeDamage(5);
        }

        if (other.gameObject.CompareTag("Healer")) {
            playerStats.IncreaseHealth(15);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SubBossAttack"))
        {
            playerStats.TakeDamage(30);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("SubBoss2Attack")) {
            playerStats.TakeDamage(40);
            Destroy(other.gameObject);
        }
    }


}
