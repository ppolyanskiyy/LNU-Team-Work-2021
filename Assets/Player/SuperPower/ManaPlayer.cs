using UnityEngine;
using System.Collections.Generic;


public class ManaPlayer : MonoBehaviour
{
    [SerializeField] float currentMana;
    [SerializeField] float maxMana;
    [SerializeField] SliderBar manaBar;
    [SerializeField] GameObject plazmaBurst;
    [SerializeField] float lenghtSpherePlazma;
    [SerializeField] float damage;
    List<GameObject> enemyes;
    private AudioSource audioBurst;

    void Start()
    {
        manaBar.SetMax(maxMana);
        manaBar.SetCurrent(currentMana);
        audioBurst = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        enemyes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Target"));
        if (currentMana < 100)
        {
            currentMana += (float) System.Math.Round((double) (7 * Time.deltaTime), 1);
            manaBar.SetCurrent(currentMana);
        }
        if (Input.GetKeyDown(KeyCode.Q) && currentMana >= 100)
        {
            audioBurst.Play();
            Instantiate(plazmaBurst, transform.position, Quaternion.LookRotation(transform.position));
            currentMana = 0;
            manaBar.SetCurrent(currentMana);

            if (enemyes.Count > 0)
            {
                foreach (var item in enemyes)
                {
                    if (Vector3.Distance(item.transform.position, transform.position) <= lenghtSpherePlazma)
                    {
                        item.GetComponent<Target>().enemiesTakeDamage(damage);
                    }
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lenghtSpherePlazma);
    }
}
