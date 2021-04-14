using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControl : MonoBehaviour
{
    Animator animator;
    private float _walkingSpeed = 2.0f;
    private float _runningSpeed = 5.0f;
    private GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gun = GameObject.Find("Shooter");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) //walk forwards
        {
            animator.SetBool("isWalkingPistol", true);
            transform.position += transform.forward * Time.deltaTime * _walkingSpeed;

            if (Input.GetKey("left shift")) //runs forward
            {
                animator.SetBool("isRunningPistol", false);
                transform.position += transform.forward * Time.deltaTime * _runningSpeed;
            }
            else
            {
                animator.SetBool("isRunningPistol", false);
            }
        }       
        else {
            animator.SetBool("isWalkingPistol", false);
        }

        if (Input.GetKey("d")) //walk right
        {
            animator.SetBool("moveRight", true);
            transform.position += transform.right * Time.deltaTime * _walkingSpeed;
        }
        else {
            animator.SetBool("moveRight", false);
        }

        if (Input.GetKey("a")) // walk left
        {
            animator.SetBool("moveLeft", true);
            transform.position += transform.right * -1 * Time.deltaTime * _walkingSpeed;
        }
        else {
            animator.SetBool("moveLeft", false);
        }

        if (Input.GetKey("s")) //walk backwards
        {
            animator.SetBool("moveBack", true);
            transform.position += transform.forward * -1 * Time.deltaTime * _walkingSpeed;
        }
        else {
            animator.SetBool("moveBack", false);
        }

        if (Input.GetKey("e")) //melee attack
        {
            animator.SetBool("melee", true);
        }
        else {
            animator.SetBool("melee", false);
        }

        if (Input.GetButton("Fire2")) //shoot bullet
        {
            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
            gun.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        }
       
    }
}
