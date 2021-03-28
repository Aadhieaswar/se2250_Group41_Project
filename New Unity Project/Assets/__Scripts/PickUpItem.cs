using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject gun;
    [SerializeField] GameObject hero;
    private GameObject heldWeapon;
    private GameObject pickedUpWeapon;
    void Start()
    {
        heldWeapon = gun.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gun.transform.localPosition = Vector3.zero;
    }

    public void OnTriggerEnter(Collider other)
    {
        heldWeapon.gameObject.SetActive(false);
        pickedUpWeapon = other.gameObject;
        pickedUpWeapon.transform.parent = gun.transform;
        pickedUpWeapon.transform.position = gun.transform.position;
        pickedUpWeapon.transform.rotation = Quaternion.Euler(hero.transform.rotation.x, hero.transform.rotation.y - 90f, hero.transform.rotation.z);
    }
}
