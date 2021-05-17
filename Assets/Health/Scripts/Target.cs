using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] SliderBar healthBarEnemies;
    [SerializeField] GameObject burst;
    private AudioSource audioBurst;
    [SerializeField] float currentHealth;

    void Start()
    {
        healthBarEnemies.SetMax(currentHealth);
        Debug.Log("Start");
        audioBurst = GetComponent<AudioSource>();
    }

    public void enemiesTakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBarEnemies.SetCurrent(currentHealth);

        if (currentHealth <= 0f)
        {
            audioBurst.Play();
            Instantiate(burst, transform.position, Quaternion.LookRotation(transform.position));
            Destroy(gameObject);
        }
    }
}
