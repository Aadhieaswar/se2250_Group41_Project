using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FinalBoss : MonoBehaviour
{
    public float lookRadius = 30f;
    public Animator animator;
    public FinalBossShooter1 shooter;

    Transform _target;
    NavMeshAgent _agent;

    void Start()
    {
        _target = PlayerManager.instance.player.transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(_target.position, transform.position);

        animator.SetFloat("Distance", distance);

        //finalboss walks towards player
        if (distance <= lookRadius)
        {
            _agent.SetDestination(_target.transform.position);

            //final boss attacks player from specific distace
            if (distance <= _agent.stoppingDistance)
            {
                FinalBossStats stats = GetComponent<FinalBossStats>();

                // trigger the attack1 animation
                animator.SetBool("PlayAttack1", true);

                // face the target
                FaceTarget();
            }
            else
            {
                animator.SetBool("PlayAttack1", false);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //shows how close the player has to be for the finalboss to start walking
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
