using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
            Destroy(other.gameObject);

        if (other.CompareTag("SubBossAttack"))
            Destroy(other.gameObject);
    }
}
