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
        levelUpUI.SetActive(true);
    }

    void HideLevelUpOption()
    {
        levelUpUI.SetActive(false);
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
