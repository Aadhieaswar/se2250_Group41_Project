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
    public void DeductHealth(float deductHealth)
    {
        henchmanHealth -= deductHealth;
        if(henchmanHealth <= 0)
        {
            henchmanDead();
        }
    }
    void henchmanDead()
    {
        animationStateController.HenchmanDeathAnim();
        
    }
}
