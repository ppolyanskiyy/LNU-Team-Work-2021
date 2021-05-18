using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public HealthBar healthBar;

    void playerTakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
