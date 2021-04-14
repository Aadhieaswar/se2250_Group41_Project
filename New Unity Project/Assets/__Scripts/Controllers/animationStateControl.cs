using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControl : MonoBehaviour
{
    Animator animator;
    private float walkingSpeed = 2.0f;
    private float runningSpeed = 5.0f;
    private GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gun = GameObject.Find("Shooter");
    }

    //Detect keys to initiate animations and movement
    void Update()
    {
        if (Input.GetKey("w"))
        {
            animator.SetBool("isWalkingPistol", true);
            transform.position += transform.forward * Time.deltaTime * walkingSpeed;
            if (Input.GetKey("left shift"))
            {
                animator.SetBool("isRunningPistol", false);
                transform.position += transform.forward * Time.deltaTime * runningSpeed;
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
            transform.position += transform.right * Time.deltaTime * walkingSpeed;
        }
        else {
            animator.SetBool("moveRight", false);
        }
        if (Input.GetKey("a"))
        {
            animator.SetBool("moveLeft", true);
            transform.position += transform.right * -1 * Time.deltaTime * walkingSpeed;
        }
        else {
            animator.SetBool("moveLeft", false);
        }
        if (Input.GetKey("s"))
        {
            animator.SetBool("moveBack", true);
            transform.position += transform.forward * -1 * Time.deltaTime * walkingSpeed;
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

        //When right click is pressed, move the camera based on the x-axis of the mouse
        if (Input.GetButton("Fire2"))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
            gun.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }
       
    }
}
