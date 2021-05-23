using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] SliderBar healthBar;
    [SerializeField] GameObject looseScene;

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
            var enemyes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Target"));
            foreach (var item in enemyes)
            {
                //var a = item.GetComponent<Canvas>();
                //var a2 = a.GetComponent<Billboard>();
                //a2.NewCamera();
                item.SetActive(false);
            }
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            if (!looseScene.activeSelf)
                looseScene.SetActive(true);

            Destroy(gameObject);
        }
    }
}
