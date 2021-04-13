using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    #region Singleton
    public static LevelUpMenu S;

    private void Awake()
    {
        S = this;
    }
    #endregion

    public GameObject levelUpUI;

    public void ShowLevelUpOption()
    {
        // set the UI to active
        levelUpUI.SetActive(true);

        // pause game
        Time.timeScale = 0f;
    }

    void HideLevelUpOption()
    {
        // set the UI to inactive
        levelUpUI.SetActive(false);

        // resume game
        Time.timeScale = 1f;
    }

    public void IncreaseAtk()
    {
        // get the new damage
        int increasedDmg = PlayerManager.instance.player.GetComponent<PlayerStats>().damage.GetValue() + 10;
        increasedDmg = Mathf.Clamp(increasedDmg, 0, int.MaxValue);

        // update the damage in the PlayerStats script of the player
        PlayerManager.instance.player.GetComponent<PlayerStats>().damage.SetValue(increasedDmg);

        // update the player's damage in the PlayerPrefs
        PlayerPrefs.SetInt("PlayerCurrentDamage", increasedDmg);

        HideLevelUpOption();
    }

    public void IncreaseHealth()
    {
        // get the new Max health
        int maxHp = PlayerManager.instance.player.GetComponent<PlayerStats>().maxHealth + 20;
        maxHp = Mathf.Clamp(maxHp, 0, int.MaxValue);

        // set the new max health and current health
        PlayerManager.instance.player.GetComponent<PlayerStats>().maxHealth = maxHp;
        PlayerManager.instance.player.GetComponent<PlayerStats>().currentHealth = maxHp;
        PlayerManager.instance.player.GetComponent<PlayerStats>().healthBar.SetMaxHealth(maxHp);

        // update the PlayerPrefs
        PlayerPrefs.SetInt("PlayerCurrentMaxHealth", maxHp );
        PlayerPrefs.SetInt("PlayerCurrentHealth", maxHp);

        HideLevelUpOption();
    }
}
