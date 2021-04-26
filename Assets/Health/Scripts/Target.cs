using UnityEngine;

public class Target : MonoBehaviour
{
    public HealthBar healthBarEnemies;
    public float currentHealth;

    void Start()
    {
        healthBarEnemies.SetMaxHealth(currentHealth);
    }

    public void enemiesTakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBarEnemies.SetHealth(currentHealth);

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
