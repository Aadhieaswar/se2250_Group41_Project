using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLevelManager : MonoBehaviour
{
    # region Singleton
    public static PlayerLevelManager S;

    void Awake()
    {
        S = this;
    }
    #endregion

    // fields
    public TextMeshProUGUI levelUI;

    void Start() //displays player level on GUI
    {
        int playerLevel = PlayerPrefs.GetInt("PlayerLevel", 1);

        levelUI.SetText("Level " + playerLevel);
    }

    public void UpdateLevel(int level) //updates player level on GUI
    {
        levelUI.text = "Level " + level;
    }
}
