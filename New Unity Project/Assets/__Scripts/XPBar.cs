using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    // fields
    public Slider slider;

    public void SetMaxXp(int XP)
    {
        slider.maxValue = XP;
        slider.value = 0;
    }

    public void SetXp(int XP)
    {
        slider.value = XP;
    }
}
