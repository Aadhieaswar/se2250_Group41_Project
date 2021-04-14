using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private GameObject gun;
    [SerializeField] private float speed;
    void Start()
    {
        projectile = GetComponent<Rigidbody>();
        gun = GameObject.Find("Hero");
    }

    //The velocity is equal to the transform of the gun times the initialized speed
    void Update()
    {
        projectile.velocity = gun.transform.forward * speed;
    }
}
