using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    GameObject playerBaseShip = null;

    public Camera playerCamera;
    public float minSize = 2f;
    public float maxSize = 5f;
    public float zoomSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GetPlayerShip();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBaseShip == null)
        {
            GetPlayerShip();
        }

        Vector3 pos = transform.position;
        float startZ = transform.position.z;
        pos = playerBaseShip.transform.position;
        pos.z = startZ;
        transform.position = pos;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float newSize = playerCamera.orthographicSize - scroll * zoomSpeed;
            playerCamera.orthographicSize = Mathf.Clamp(newSize, minSize, maxSize);
        }
    }

    private void GetPlayerShip()
    {
        playerBaseShip = GameObject.Find("playerBaseShip");
    }
}
