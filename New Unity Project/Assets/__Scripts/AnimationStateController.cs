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

        //the henchman only starts to walk and attack once the player is within certain distance
        if(distance >=50 && !isDead){
            agent.updatePosition = false;
            agent.SetDestination(target.position);
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isAttackingHash, false);
        }
        else if(distance >= 4.5 && !isDead)
        {
            agent.updatePosition = true;
            agent.SetDestination(target.position);
            animator.SetBool(isWalkingHash, true);
            animator.SetBool(isAttackingHash, false);
        }
        //henchman stops a certain distance from player and starts attacking
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

    //shows how close the player has to be for the henchman to start walking
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 50);
    }
}
