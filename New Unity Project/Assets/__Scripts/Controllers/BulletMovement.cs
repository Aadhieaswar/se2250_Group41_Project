using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private GameObject gun;
    [SerializeField] private float _speed;
    void Start()
    {
        projectile = GetComponent<Rigidbody>();
        gun = GameObject.Find("Hero");
    }

    // Update is called once per frame
    void Update()
    { 
        //shoots the bullet in forward direction of player
        projectile.velocity = gun.transform.forward * _speed;
    }
}
