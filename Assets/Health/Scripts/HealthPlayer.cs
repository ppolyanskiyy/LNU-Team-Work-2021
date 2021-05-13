using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] SliderBar healthBar;
    [SerializeField] Transform mainCamera;

    void Start()
    {
        healthBar.SetMax(currentHealth);
    }

    public void RaiseHP(float hp)
    {
        if (currentHealth + hp >= 100)
        {
            currentHealth = 100;
            healthBar.SetCurrent(currentHealth);
        }
        else
        {
            currentHealth += hp;
            healthBar.SetCurrent(currentHealth);
        }

    }

    public void playerTakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetCurrent(currentHealth);

        if (currentHealth <= 0)
        {
            var billboards = new List<GameObject>(GameObject.FindGameObjectsWithTag("Billboard"));
            //mainCamera.SetActive;
            foreach (var item in billboards)
                item.GetComponent<Billboard>().cam = mainCamera;

            var mainCameraTags = new List<GameObject>(GameObject.FindGameObjectsWithTag("MainCamera"));
            foreach (var item in mainCameraTags)
                Destroy(item);

            Destroy(gameObject);
        }
    }
}
