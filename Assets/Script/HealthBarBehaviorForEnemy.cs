using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviorForEnemy : MonoBehaviour
{

    public Slider Slider;
    public Color LowHealth;
    public Color HighHealth;

    public Vector3 OffSet;

    public void SetHealth(float health, float maxhealth)
    {
        Slider.gameObject.SetActive(health < maxhealth);
        Slider.value = health;
        Slider.maxValue = maxhealth;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(LowHealth, HighHealth, Slider.normalizedValue);
    }

    void Update()
    {
        Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + OffSet);
    }
}
