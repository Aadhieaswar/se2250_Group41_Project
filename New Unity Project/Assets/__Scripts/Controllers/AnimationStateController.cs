using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationStateController : MonoBehaviour
{
    public float lookRadius = 10f;
    public Animator animator;

    Transform target;
    NavMeshAgent agent;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        agent.updatePosition = false;
        float distance = Vector3.Distance(transform.position, target.position);

        //enemy walks towards player
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            animator.SetBool("isWalking", true);
            agent.updatePosition = true;

            //enemy attacks player at given distance
            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
                agent.updatePosition = false;

                // face the target
                FaceTarget();
            }
            else
            {
                animator.SetBool("isAttacking", false);
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

public void HenchmanDeathAnim()
    {
        animator.SetTrigger("isDead");
    }

    //shows how close the player has to be for the henchman to start walking
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 50);
    }
}
