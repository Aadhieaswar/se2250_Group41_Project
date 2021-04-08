using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; protected set; }
    
    public HealthBar healthBar;

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
        InitializeStatus();
    }

    public virtual void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (healthBar != null)
            healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //public void IncreaseHealth(int health) {
    //    currentHealth += health;
    //    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    //    healthBar.SetHealth(currentHealth);
    //}

    public virtual void InitializeStatus()
    {
        if (healthBar != null)
            healthBar.SetMaxHealth(maxHealth);

        // can be overriden to instantiate other stuff in the awake method
    }

    public virtual void Die()
    {
        // method to be overriden for death of each character
    }
}
