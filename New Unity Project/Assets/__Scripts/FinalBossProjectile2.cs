using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossProjectile2 : MonoBehaviour
{
    public ParticleSystem ps;

    List<ParticleCollisionEvent> collEvents = new List<ParticleCollisionEvent>();

    private void Start()
    {
        //the final bosses speial attack
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int events = ps.GetCollisionEvents(other, collEvents);

        for (int i = 0; i < events; i++)
        {
            //checks if players hitbx is attacked before decreasing player health
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerStats>().TakeDamage(15);
            }
        }
    }
}
