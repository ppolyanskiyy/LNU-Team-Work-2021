using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] SliderBar healthBar;


    public void playerTakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetCurrent(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
