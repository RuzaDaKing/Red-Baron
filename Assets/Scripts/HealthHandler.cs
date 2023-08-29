using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    public int health = 100; // Initial health value
    public InfoBarHandler InfoBarHandler;

    private void Start()
    {
        InfoBarHandler.SetMaxHealth(health);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        InfoBarHandler.SetHealth(health);

        if (health <= 0)
        {
            // Handle death or destruction
            // Example: Call a method to destroy the game object
            Destroy(gameObject);
        }
    }
}
