using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthBar;
    private float currentHealth;

    void Start()
    {
        healthBar = GetComponent<Slider>();
        currentHealth = healthBar.maxValue;
        healthBar.value = currentHealth;
    }


    public void GetDamage(float dmg)
    {
        currentHealth -= dmg;
        healthBar.value = currentHealth;
    }
}
