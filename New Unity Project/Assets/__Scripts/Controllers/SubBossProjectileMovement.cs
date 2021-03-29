using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBossProjectileMovement : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Rigidbody rb;
    public float speed = 100f;

    Transform target;

    private void Start()
    {
        target = GameObject.Find("SubBoss").transform;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = target.transform.forward * speed;   
    }
}
