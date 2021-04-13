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

    void Start()
    {
        int playerLevel = PlayerPrefs.GetInt("PlayerLevel", 1);

        levelUI.SetText("Level " + playerLevel);
    }

    public void UpdateLevel(int level)
    {
        levelUI.text = "Level " + level;
    }
}
