using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenchmanHealth : MonoBehaviour
{
    public float henchmanHealth = 100f;
    AnimationStateController animationStateController;

    private void Start()
    {
        animationStateController = GetComponent<AnimationStateController>();
    }
    public void DeductHealth(float deductHealth) //when enemy takes damage
    {
        henchmanHealth -= deductHealth;
        if(henchmanHealth <= 0)
        {
            //when enemey is 0hp, it dies
            henchmanDead();
        }
    }
    void henchmanDead() //calls death animation
    {
        animationStateController.HenchmanDeathAnim();
        
    }
}
