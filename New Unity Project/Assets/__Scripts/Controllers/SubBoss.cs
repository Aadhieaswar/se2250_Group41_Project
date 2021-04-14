using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SubBoss : MonoBehaviour
{
    //Create a look radius that can be set in the inspector
    public float lookRadius;
    public Animator animator;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate distance to the player
        float distance = Vector3.Distance(target.position, transform.position);
        //Make the subboss able to walk depending the distance
        animator.SetFloat("Distance", distance);
        //If distance is less than or equal to the look radius, the subboss walks towards the player
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            //When subboss gets to the stopping distance, have it fire its projectile
            if (distance <= agent.stoppingDistance)
            {

                animator.SetBool("IsAttacking", true);

                // face the target
                FaceTarget();
            }
            else 
            {
                animator.SetBool("IsAttacking", false);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
