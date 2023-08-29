using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int damageAmount = 20; // Amount of damage the projectile inflicts

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Get the enemy script reference
            HealthHandler healthHandler = other.GetComponent<HealthHandler>();

            // Inflict damage to the enemy
            healthHandler.TakeDamage(damageAmount);

            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
