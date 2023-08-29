using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireCooldown = 0.25f;
    float cooldownTimer = 0f;
    public float offset = 1f;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if(Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            cooldownTimer = fireCooldown;

            Vector3 offset = transform.rotation * new Vector3(0, 0.16f, 0);
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
