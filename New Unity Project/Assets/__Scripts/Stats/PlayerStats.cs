using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    // new fields
    public XPBar xpBar;
    public int xp { get; private set; }
    public int currentMaxXp = 20;

    public override void InitializeStatus()
    {
        base.InitializeStatus();
        xp = 0;
        xpBar.SetMaxXp(currentMaxXp);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        PlayerManager.currentHealth = this.currentHealth;
    }

    public void IncreaseXp(int XP)
    {
        xp += XP;
        if (xp >= currentMaxXp)
        {
            LevelUp();
            return;
        }
        xpBar.SetXp(xp);
    }

    public void LevelUp()
    {
        currentMaxXp += (int)(currentMaxXp * 0.25);

        xpBar.SetMaxXp(currentMaxXp);

        // reset xp value
        xp -= maxHealth;

        // Show Level in status bar
        PlayerManager.instance.LevelUpPlayer();

        // code for selecting power up
        LevelUpMenu.S.ShowLevelUpOption();
    }

    public override void Die()
    {
        base.Die();
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseHealth(int health) {
        currentHealth += health;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        PlayerManager.currentHealth = this.currentHealth;
    }

    // property to set damage of player
    public int dmg
    {
        set
        {
            this.damage.SetValue(value);
        }

        get
        {
            return this.damage.GetValue();
        }
    }

    // property to set health of player
    public int currHp
    {
        set
        {
            this.currentHealth = value;
            this.currentHealth = Mathf.Clamp(this.currentHealth, 0, int.MaxValue);

            healthBar.SetHealth(this.currentHealth);
        }

        get
        {
            return this.currentHealth;
        }
    }

    // property to set max health of player
    public int currMaxHp
    {
        set
        {
            this.maxHealth = value;
            this.maxHealth = Mathf.Clamp(this.maxHealth, 0, int.MaxValue);

            healthBar.SetMaxHealth(this.maxHealth);
        }

        get
        {
            return this.maxHealth;
        }
    }
}
