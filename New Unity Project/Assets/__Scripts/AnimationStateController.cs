using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationStateController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    Transform target;
    int isWalkingHash;
    int isAttackingHash;
    bool isDead = false;
   
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isAttackingHash = Animator.StringToHash("isAttacking");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        bool isAttacking = animator.GetBool(isAttackingHash);
        bool isWalking = animator.GetBool(isWalkingHash);
    
        if(distance > 3 && !isDead)
        {
            agent.updatePosition = true;
            agent.SetDestination(target.position);
            animator.SetBool(isWalkingHash, true);
            animator.SetBool(isAttackingHash, false);
        }
        else
        {
            agent.updatePosition = false;
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isAttackingHash, true);
        }
       
    }
    public void HenchmanDeathAnim()
    {
        isDead = true;
        animator.SetTrigger("isDead");
    }
}
