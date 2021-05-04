using UnityEngine;

public class Target : MonoBehaviour
{
    public SliderBar healthBarEnemies;
    

    public float currentHealth;
    void Start()
    {
        healthBarEnemies.SetMax(currentHealth);
        Debug.Log("Start");
    }

    public void enemiesTakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBarEnemies.SetCurrent(currentHealth);

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
