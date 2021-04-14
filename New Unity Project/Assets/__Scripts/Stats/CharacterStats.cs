using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //attributes
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Stat damage;

    //Awake function is called and currentHealth is set to max Health and it Intializes Status 
    private void Awake()
    {
        currentHealth = maxHealth;
        InitializeStatus();
    }

    //This method will take hits and will deduct health and if health equals 0, it is dead
    public void TakeDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (healthBar != null)
            healthBar.SetHealth(currentHealth);

        AdditionalDmgOperations();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void AdditionalDmgOperations()
    {
        // method to be overriden incase to add more items when taking damage
    }

    public virtual void InitializeStatus()
    {
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }

        // can be overriden to instantiate other stuff in the awake method
    }

    public virtual void Die()
    {
        // method to be overriden for death of each character
    }
}
