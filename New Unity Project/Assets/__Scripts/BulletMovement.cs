using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private float speed;
    void Start()
    {
        projectile = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        projectile.velocity = Vector3.forward * speed;
    }
}
