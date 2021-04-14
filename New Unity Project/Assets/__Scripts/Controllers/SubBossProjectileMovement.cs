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
        if (target != null)
            rb.velocity = target.forward * speed;
    }

    public void FindShooter() {
        if (GameObject.Find("SubBoss") == null)
        {
            target = GameObject.Find("Hero").transform;
        }
        else
        {
            target = GameObject.Find("SubBoss").transform;
        }
    }
}
