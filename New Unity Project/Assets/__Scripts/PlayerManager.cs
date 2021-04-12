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

    public readonly string playerLevelKey = "PlayerLevel";

    public void KillPlayer()
    {
        // delete all stored values
        //PlayerPrefs.DeleteAll();

        // load the main menu scene
        SceneManager.LoadSceneAsync(0);
    }

    public void LevelUpPlayer()
    {
        int playerLevel = PlayerPrefs.GetInt(playerLevelKey, 1) + 1;

        PlayerPrefs.SetInt(playerLevelKey, playerLevel);

        PlayerLevelManager.S.UpdateLevel(playerLevel);
    }
}
