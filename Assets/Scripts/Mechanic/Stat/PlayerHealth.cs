using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 70;
    private int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Die!");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basement"))
        {
            InvokeRepeating("TakeDamage", 0f, 1f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Basement"))
        {
            CancelInvoke("TakeDamage");
        }
    }
}
