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

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(string scene)
    {
        StartCoroutine(LoadLevelAndSetActive(scene));
    }

    public void Unload(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }

    IEnumerator LoadLevelAndSetActive(string level)
    {
        yield return SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);

		SceneManager.SetActiveScene(SceneManager.GetSceneByName(level));
    }
}
