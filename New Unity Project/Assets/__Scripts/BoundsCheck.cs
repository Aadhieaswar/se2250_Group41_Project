using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //destroys player bullets once they leave the scene
        if (other.CompareTag("Bullet"))
            Destroy(other.gameObject);

        //destroys subboss projectiles once they leave the scene
        if (other.CompareTag("SubBossAttack"))
            Destroy(other.gameObject);
    }
}
