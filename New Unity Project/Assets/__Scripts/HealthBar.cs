using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    // fields
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI healthStatusText;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        // set the status text
        SetHealthStatusText(health, health);

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        // set status text
        SetHealthStatusText(health, (int) slider.maxValue);

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetHealthStatusText(int health, int maxHealth)
    {
        //sets heath display in GUI
        if (healthStatusText)
            healthStatusText.SetText(health + " / " + maxHealth);
    }
}
