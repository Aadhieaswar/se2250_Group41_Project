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

    public static int playerLevel = 1;
    public static int currentDamage = 50;
    public static int currentHealth = 100;
    public static int currentMaxHealth = 100;
    public static int playerCurrentXp = 0;
    public static int playerCurrentMaxXp = 20;

    private void Start()
    {
        PlayerStats stats = instance.player.GetComponent<PlayerStats>();

        // set player damage
        stats.dmg = currentDamage;

        // set player health status
        stats.currMaxHp = currentMaxHealth;
        stats.currHp = currentHealth;

        // set player XP status
        stats.xpBar.SetMaxXp(playerCurrentMaxXp);
        stats.xpBar.SetXp(playerCurrentXp);
    }

    public void KillPlayer()
    {
        // reset stats 
        ResetStats();

        // load the main menu scene
        SceneManager.LoadScene(0);
    }

    public void LevelUpPlayer()
    {
        playerLevel++;

        PlayerLevelManager.S.UpdateLevel(playerLevel);
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

    void ResetStats()
    {
        playerLevel = 1;

        currentDamage = 50;

        currentHealth = 100;
        currentMaxHealth = 100;

        playerCurrentXp = 0;
        playerCurrentMaxXp = 20;
    }
}
