using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [Header("Set in Inspector")]
    public GameObject healthBarGo;
    public Canvas canvas;

    GameObject bar;

    private void Start()
    {
        bar = Instantiate(healthBarGo);
        bar.transform.SetParent(canvas.transform, false);
        bar.transform.localPosition = new Vector3(0, 0, 0);

        healthBar = bar.GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
    }

    public override void Die()
	{
		base.Die();

        // Add ragdoll effect / death animation
        this.GetComponent<Animator>().SetBool("IsDead", true);

		//Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(50);
        }
        if (other.gameObject.CompareTag("Melee")) {
            TakeDamage(25);
        }
    }
}
