using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBossProjectileMovement : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Rigidbody rb;
    public float speed = 100f;

    protected Transform target;

    private void Start()
    {
        FindShooter();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    }

    protected void Move() {
        //moves the subboss projectile forward
        if (target != null)
            rb.velocity = target.forward * speed;
    }

    //Find subboss 2 and if not attach the target to the game object that fires the projectile from the player
    public virtual void FindShooter() {
        if (GameObject.Find("SubBoss") == null)
        {
            target = GameObject.Find("SpecialAttackShooter").transform;
        }
        else
        {
            target = GameObject.Find("SubBoss").transform;
        }
    }
}
