using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossProjectile2 : MonoBehaviour
{
    public ParticleSystem ps;

    List<ParticleCollisionEvent> collEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int events = ps.GetCollisionEvents(other, collEvents);

        for (int i = 0; i < events; i++)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerStats>().TakeDamage(10);
            }
        }
    }
}
