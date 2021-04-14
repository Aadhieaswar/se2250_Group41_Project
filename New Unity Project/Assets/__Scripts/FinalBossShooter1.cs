using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBossShooter1 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public ParticleSystem ps;
    public Animator animator;
    public NavMeshAgent agent;

    float attacksPerSecond = 0.5f;
    float currrentTime = 0;

    void Update()
    {
        transform.LookAt(PlayerManager.instance.player.transform);
        ThrowProjectile();
    }

    void ThrowProjectile()
    {
        if (currrentTime >= (1f / attacksPerSecond))
        {
            if (animator.GetBool("PlayAttack1") && animator.GetFloat("Distance") < agent.stoppingDistance)
            {
                ps.Play();

                currrentTime = 0;
            }
        }
        else
        {
            currrentTime += Time.deltaTime;
        }
    }

    public void Shoot()
    {
        ps.Play();
    }
}
