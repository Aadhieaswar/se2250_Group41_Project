using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBossShooter2 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public ParticleSystem ps;
    public NavMeshAgent agent;
    public Animator animator;
    public FinalBoss finalBoss;

    bool _isPlaying = false;

    void Update()
    {
        StartEmission();
    }

    void StartEmission()
    {
        float distance = animator.GetFloat("Distance");
        if (distance < finalBoss.lookRadius && distance > agent.stoppingDistance && !_isPlaying)
        {
            ps.Play();
            _isPlaying = true;
        }
        else
        {
            ps.Stop();
            _isPlaying = false;
        }
    }
}
