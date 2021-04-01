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
        animationStateController.HenchmanDeathAnim();

        PlayerStats playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
        playerStats.IncreaseXp(5);

        Destroy(gameObject, 3f);
        if (random == 1)
        {
            InstantiateHealer();
        }
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

    private void InstantiateHealer() {
        heldHealer.transform.position = this.transform.position;
        Vector3 heldHealerPosition = heldHealer.transform.position;
        Instantiate(heldHealer, new Vector3(heldHealerPosition.x, heldHealerPosition.y + 3, heldHealerPosition.z),Quaternion.Euler(0f, 0f, 0f));
    }
}
