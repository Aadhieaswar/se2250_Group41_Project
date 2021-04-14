using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBossShooter2 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public ParticleSystem ps;
    public float speed = 50f;
    public NavMeshAgent agent;
    public Animator animator;
    public FinalBossStats stats;
    public Transform target;

    bool _isPlaying;

    private void Start()
    {
        _isPlaying = false;
    }

    void Update()
    {
        StartEmission();
    }

    void StartEmission() //final bosses special attack
    {
        if (stats.currentHealth < (stats.maxHealth * 0.3)) //activates onces boss is below 30% hp
        {
            if (!_isPlaying)
            {
                ps.Play();

                _isPlaying = true;
            }

            //transform.Translate(stats.gameObject.transform.forward);
            GetComponent<Rigidbody>().velocity = target.transform.forward * speed;
        }
    }
}
