using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;

    public static int currentDamage = 50;
    public static int currentHealth = 100;
    public static int currentMaxHealth = 100;

    private void Start()
    {
        PlayerStats stats = instance.player.GetComponent<PlayerStats>();

        stats.dmg = currentDamage;
        stats.currMaxHp = currentMaxHealth;
        stats.currHp = currentHealth;

        // debug
        print("damage: " + stats.damage.GetValue());
        print("max health: " + stats.maxHealth);
        print("curr health: " + stats.maxHealth);
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void IncreasePlayerAttack(int damage)
    {
        currentDamage += damage;
        currentDamage = Mathf.Clamp(currentDamage, 0, int.MaxValue);

        instance.player.GetComponent<PlayerStats>().dmg = currentDamage;
    }

    public static void IncreasePlayerMaxHealth(int maxHealth)
    {
        currentMaxHealth += maxHealth;
        currentMaxHealth = Mathf.Clamp(currentMaxHealth, 0, int.MaxValue);

        currentHealth = currentMaxHealth;

        instance.player.GetComponent<PlayerStats>().currMaxHp = currentMaxHealth;
    }
}
