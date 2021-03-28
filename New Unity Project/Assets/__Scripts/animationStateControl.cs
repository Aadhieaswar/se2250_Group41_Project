using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControl : MonoBehaviour
{
    Animator animator;
    private float walkingSpeed = 2.0f;
    private float runningSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            animator.SetBool("isWalkingPistol", true);
            transform.position += Vector3.forward * Time.deltaTime * walkingSpeed;
            if (Input.GetKey("left shift"))
            {
                animator.SetBool("isRunningPistol", false);
                transform.position += Vector3.forward * Time.deltaTime * runningSpeed;
            }
            else
            {
                animator.SetBool("isRunningPistol", false);
            }
        }
        else {
            animator.SetBool("isWalkingPistol", false);
        }

        if (Input.GetKey("d"))
        {
            animator.SetBool("moveRight", true);
            transform.position += Vector3.right * Time.deltaTime;
        }
        else {
            animator.SetBool("moveRight", false);
        }
        if (Input.GetKey("a"))
        {
            animator.SetBool("moveLeft", true);
            transform.position += Vector3.left * Time.deltaTime;
        }
        else {
            animator.SetBool("moveLeft", false);
        }
        if (Input.GetKey("s"))
        {
            animator.SetBool("moveBack", true);
            transform.position += Vector3.back * Time.deltaTime * walkingSpeed;
        }
        else {
            animator.SetBool("moveBack", false);
        }
        if (Input.GetKey("e"))
        {
            animator.SetBool("melee", true);
        }
        else {
            animator.SetBool("melee", false);
        }

       
    }
}
