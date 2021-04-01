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

    public void IncreaseXp(int XP)
    {
        xp += XP;
        if (xp >= currentMaxXp)
        {
            LevelUp();
            return;
        }
        xpBar.SetXp(xp);
        print("XP increased");
    }

    public void LevelUp()
    {
        currentMaxXp += (int)(currentMaxXp * 0.25);
        xpBar.SetMaxXp(currentMaxXp);

        // code for selecting power up (to be added later)
    }

    public override void Die()
    {
        base.Die();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
