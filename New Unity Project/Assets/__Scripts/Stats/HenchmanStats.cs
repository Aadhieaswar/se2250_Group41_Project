using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenchmanStats : CharacterStats
{
    [Header("Set in Inspector")]
    public GameObject healthBarGo;
    public GameObject heldHealer;
    public Canvas canvas;
    private int random;

    AnimationStateController animationStateController;
    GameObject bar;
    bool _isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        bar = Instantiate(healthBarGo);
        bar.transform.SetParent(canvas.transform, false);
        bar.transform.localPosition = new Vector3(0, 0, 0);

        healthBar = bar.GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

        animationStateController = GetComponent<AnimationStateController>();

        random = Random.Range(0, 2);
    }

    public override void Die()
    {
        base.Die();

        // give the player XP points on death
        if (_isAlive)
        {
            // give player xp for the kill
            PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
            playerStats.IncreaseXp(5);

            //increase killounter
            Sub_Spawner.killCount++;

            // play the death animation
            animationStateController.HenchmanDeathAnim();

            // instantiate the healer (on condition)
            if (random == 1)
            {
                InstantiateHealer();
            }

            // update variable
            _isAlive = false;
        }

        Destroy(gameObject, 3f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(50);
        }
        if (other.gameObject.CompareTag("Melee"))
        {
            TakeDamage(25);
        }
    }

    private void InstantiateHealer()
    {
        heldHealer.transform.position = this.transform.position;
        Vector3 heldHealerPosition = heldHealer.transform.position;
        Instantiate(heldHealer, new Vector3(heldHealerPosition.x, heldHealerPosition.y + 3, heldHealerPosition.z), Quaternion.Euler(0f, 0f, 0f));
    }
}
