using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] SliderBar healthBarEnemies;
    [SerializeField] GameObject burst;


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
            Instantiate(burst, transform.position, Quaternion.LookRotation(transform.position));
            Destroy(gameObject);
        }
    }
}
