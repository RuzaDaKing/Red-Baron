using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float preferredRange = 5f;
    public float movementSpeed = 3f;
    public float rotationSpeed = 5f;

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > preferredRange)
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            RotateTowards(direction);
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else if (distanceToPlayer < preferredRange)
        {
            // Move away from the player
            Vector2 direction = (transform.position - player.position).normalized;
            RotateTowards(direction);
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
    }

    void RotateTowards(Vector2 direction)
    {
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

