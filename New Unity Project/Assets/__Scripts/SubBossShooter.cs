using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBossShooter : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject projectile;
    public Animator animator;
    public float attacksPerSecond = 0.25f;

    float currentTime;

    void Update()
    {
        //called every frame
        ThrowProjectile();
    }

    public void ThrowProjectile()
    {
        //checks to see if enemy is within attacking distane
        if (animator.GetBool("IsAttacking") && animator.GetFloat("Distance") < 20)
            //controls the attack rate
            currentTime += Time.deltaTime;

        if (currentTime >= (1f/attacksPerSecond))
        {

            GameObject proj = Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, 0f));

            currentTime = 0.0f;
        }
    }
}
