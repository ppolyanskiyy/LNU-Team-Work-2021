using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public float currentHealth;
    public Transform mainCamera;
    public HealthBar healthBar;
    public Billboard cameraBillboard;

    void Start()
    {
        healthBar.SetMaxHealth(currentHealth);
    }

    public void playerTakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            cameraBillboard.camera = mainCamera;
            Destroy(gameObject);
        }
    }
}
