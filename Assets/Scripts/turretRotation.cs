using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust the rotation speed as needed
    
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float targetAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle));

        // Gradually rotate towards the target rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
