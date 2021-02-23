using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // fields
    [Header("Set in Inspector")]
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxis("Horizontal");
        float zPos = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xPos * speed * Time.deltaTime;
        pos.z += zPos * speed * Time.deltaTime;

        transform.position = pos;
    }
}
