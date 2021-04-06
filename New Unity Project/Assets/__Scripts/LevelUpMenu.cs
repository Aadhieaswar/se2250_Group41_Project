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
        // code to increase player attack

        HideLevelUpOption();
    }

    public void IncreaseHealth()
    {
        // code to increase player health

        HideLevelUpOption();
    }
}
