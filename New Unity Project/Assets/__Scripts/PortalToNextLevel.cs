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
            //checks if player has completed current level
            ObjectivesForLevel.S.notEnteredPortal = false;

            // load the next level
            StartCoroutine(LoadNextlevel());
        }
    }

    IEnumerator LoadNextlevel()
    {
        //waits in teleporter for 2 sec
        yield return new WaitForSeconds(2f);
        //display next level
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
