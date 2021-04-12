using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToNextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // load the next level
            StartCoroutine(LoadNextlevel());
        }
    }

    IEnumerator LoadNextlevel()
    {
        yield return new WaitForSeconds(2f);

        int index = PlayerPrefs.GetInt("CurrentLevel", 1);
        index += 1;

        SceneManager.LoadSceneAsync(index);
    }
}
