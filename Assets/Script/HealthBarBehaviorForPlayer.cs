using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviorForPlayer : MonoBehaviour
{
    public Slider Slider;
    public Color LowHealth;
    public Color HighHealth;

    public void SetHealth(float health, float maxhealth)
    {
        if (health< maxhealth)
        {
            Slider.value = health;
            Slider.maxValue = maxhealth;
            Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(LowHealth, HighHealth, Slider.normalizedValue);
        }
    }
}
