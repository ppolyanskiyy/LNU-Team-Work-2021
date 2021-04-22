using UnityEngine;

public class Target : MonoBehaviour
{
    public HealthBar healthBarEnemies;

    public MoveWall firstFurnace;
    public MoveWall secondFurnace;
    public MoveWall thirdFurnace;
    

    public float currentHealth;
    void Start()
    {
        healthBarEnemies.SetMaxHealth(currentHealth);
        Debug.Log("Start");
    }

    public void enemiesTakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBarEnemies.SetHealth(currentHealth);

        if (currentHealth <= 0f)
        {

            firstFurnace.Move();
            secondFurnace.Move();
            thirdFurnace.Move();

            Destroy(gameObject);
        }
    }
}
