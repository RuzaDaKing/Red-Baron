using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5;
    public float rotSpeed = 45;
    public float acceleration = 1;
    public float deceleration = 5;
    float currentSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        acceleration /= 1000f;
        deceleration /= 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate ship
        float horizontalAxis = Input.GetAxis("Horizontal");
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= horizontalAxis * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        // move ship
        float verticalAxis = Input.GetAxis("Vertical");
        Vector3 pos = transform.position;

        if (verticalAxis != 0)
        {
            currentSpeed += verticalAxis * acceleration;
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration);
        }
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
        Vector3 velocity = new Vector3(0, Time.deltaTime * currentSpeed, 0);
        pos += rot * velocity;
        transform.position = pos;
    }
}
