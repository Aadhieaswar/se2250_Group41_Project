using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Player : MonoBehaviour
{
    // fields
    [Header("Set in Inspector")]
    public int maxHealth = 100;

    [Header("Set Dynamically")]
    public int currentHealth;
    public PlayerStats playerStats;
    private float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Have the player take damage depending on what objects collide with it
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
        if (other.gameObject.CompareTag("Lava")) {
            playerStats.TakeDamage(1);
        }
    } 
    //Have the lava continuously do damage to the player
    private void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("Lava")) {
            elapsed += Time.deltaTime;
            //player ends up taking 3 dmg every secong
            if (elapsed >= 0.3)
           {
              playerStats.TakeDamage(1);
              elapsed = 0;
           }
       } 
    }
}
