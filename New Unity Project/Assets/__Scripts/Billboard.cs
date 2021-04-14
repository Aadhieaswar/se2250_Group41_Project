using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void LateUpdate()
    {   //allows the player view to always see enemy health bar status
        transform.LookAt(Camera.main.transform, Camera.main.transform.up);
    }
}
