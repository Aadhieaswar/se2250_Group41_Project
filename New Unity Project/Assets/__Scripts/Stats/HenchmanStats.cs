using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenchmanStats : CharacterStats
{
    [Header("Set in Inspector")]
    public GameObject healthBarGo;
    public Canvas canvas;

    AnimationStateController animationStateController;
    GameObject bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = Instantiate(healthBarGo);
        bar.transform.SetParent(canvas.transform, false);
        bar.transform.localPosition = new Vector3(0, 0, 0);

        healthBar = bar.GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

        animationStateController = GetComponent<AnimationStateController>();
    }

    public override void Die()
    {
        base.Die();

        animationStateController.HenchmanDeathAnim();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(50);
        }
    }
}
