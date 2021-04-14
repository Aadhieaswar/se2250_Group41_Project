using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform projectile;
    [SerializeField] GameObject projectileGameObject;

    [SerializeField] private float interval;
    private float currentTime = 0.0f;
    void Start()
    {
        projectile = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ShootProjectile();
    }

    public void ShootProjectile() {
        //controls projectile rate
        currentTime += Time.deltaTime;
        //awaits "attack" (fire) command
        if (Input.GetButton("Fire1") && currentTime > interval) {
            //instantiates projectile
            Instantiate(projectileGameObject, projectile.transform.position, Quaternion.Euler(90f, 0f, 0f));
            currentTime = 0.0f;
        }
    }
}
