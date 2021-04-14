using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBar : MonoBehaviour
{
    // fields
    public Slider slider;
    public TextMeshProUGUI xpStatusText;

    public void SetMaxXp(int XP)
    {
        slider.maxValue = XP;
        slider.value = 0;

        // set the status text
        SetXpStatusText((int) slider.maxValue);
    }

    public void SetXp(int XP)
    {
        slider.value = XP;

        // set the status text
        SetXpStatusText((int) slider.maxValue, (int) slider.value);
    }

    public void SetXpStatusText(int maxXp, int XP = 0)
    {
        if (xpStatusText)
            //sets xp to max
            xpStatusText.SetText(XP + " / " + maxXp);
    }
}
