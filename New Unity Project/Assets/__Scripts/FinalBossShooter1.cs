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
        //aims projectiles at player
        transform.LookAt(PlayerManager.instance.player.transform);
        ThrowProjectile();
    }

    void ThrowProjectile()
    {
        //controls rate of fire
        if (currrentTime >= (1f / attacksPerSecond))
        {
            //checks if attacking distance is achieved
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
