using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    // fields
    public XPBar xpBar;
    public int xp;
    public int currentMaxXp = 20;

    [HideInInspector]
    public bool isAlive;

    public override void InitializeStatus()
    {
        // Player prefs to store player data
        maxHealth = PlayerPrefs.GetInt("PlayerCurrentMaxHealth", maxHealth);
        currentHealth = PlayerPrefs.GetInt("PlayerCurrentHealth", maxHealth);

        damage.SetValue(PlayerPrefs.GetInt("PlayerCurrentDamage", damage.GetValue()));

        xp = PlayerPrefs.GetInt("PlayerCurrentXp", 0);
        currentMaxXp = PlayerPrefs.GetInt("PlayerCurrentMaxXp", currentMaxXp);

        // initialize the statuses after getting the data
        base.InitializeStatus();

        // set up the Xp bar
        xpBar.SetMaxXp(currentMaxXp);
        xpBar.SetXp(xp);

        // initialize isAlive variable
        isAlive = true;
    }

    public override void AdditionalDmgOperations()
    {
        base.AdditionalDmgOperations();

        // update player prefs
        if (isAlive)
            PlayerPrefs.SetInt("PlayerCurrentHealth", this.currentHealth);
    }

    public void IncreaseXp(int XP)
    {
        xp += XP;

        // update player prefs
        PlayerPrefs.SetInt("PlayerCurrentXp", xp);

        if (xp >= currentMaxXp)
        {
            LevelUp();
            return;
        }
        xpBar.SetXp(xp);
    }

    void LevelUp()
    {
        int tmpMaxXp = currentMaxXp;

        currentMaxXp += (int)(currentMaxXp * 0.25);
        xpBar.SetMaxXp(currentMaxXp);

        // update player prefs
        PlayerPrefs.SetInt("PlayerCurrentMaxXp", currentMaxXp);

        // reset xp value and set it
        xp -= tmpMaxXp;
        xpBar.SetXp(xp);

        // update player prefs
        PlayerPrefs.SetInt("PlayerCurrentXp", xp);

        // Show Level in status bar
        PlayerManager.instance.LevelUpPlayer();

        // code for selecting power up
        LevelUpMenu.S.ShowLevelUpOption();
    }

    public override void Die()
    {
        base.Die();

        if (isAlive)
        {
            PlayerPrefs.DeleteAll();

            // kill the player
            PlayerManager.instance.KillPlayer();

            // update the isAlive variable
            isAlive = false;
        }
    }

    public void IncreaseHealth(int health) {
        currentHealth += health;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        // update player prefs
        PlayerPrefs.SetInt("PlayerCurrentHealth", this.currentHealth);
    }
}
