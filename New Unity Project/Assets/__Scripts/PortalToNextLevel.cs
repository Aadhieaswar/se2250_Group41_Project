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
            ObjectivesForLevel.S.notEnteredPortal = false;

            // load the next level
            StartCoroutine(LoadNextlevel());
        }
    }

    IEnumerator LoadNextlevel()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
