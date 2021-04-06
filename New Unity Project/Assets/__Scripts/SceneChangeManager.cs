using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive);
    }
}
