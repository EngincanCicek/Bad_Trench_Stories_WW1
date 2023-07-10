using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    public float speed;
    public float zoomSpeed;
    public float rotationSpeed = 0.1f;

    private float maxHeight = 150;
    private float minHeight = 20;

    Vector2 p1;
    Vector2 p2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.005f;
            zoomSpeed = 12;
        }
        else
        {
            speed = 0.002f;
            zoomSpeed = 6;

        }

        float hsp = transform.position.y * speed * Input.GetAxis("Horizontal");
        float vsp = transform.position.y * speed * Input.GetAxis("Vertical");
        float scrollSpeed = Mathf.Log(transform.position.y) * zoomSpeed * Input.GetAxis("Mouse ScrollWheel");


        if ((transform.position.y >= maxHeight) && scrollSpeed > 0)
        {
            scrollSpeed = 0;
        }
        else if ((transform.position.y <= minHeight) && scrollSpeed < 0)
        {
            scrollSpeed = 0;
        }


        Vector3 verticleMove = new Vector3(0, scrollSpeed, 0);
        Vector3 lateralMove = hsp * transform.right;
        Vector3 forwardMove = transform.forward;

        forwardMove.y = 0;
        forwardMove.Normalize();
        forwardMove *= vsp;

        Vector3 move = verticleMove + forwardMove + lateralMove;
        transform.position += move;

        getCameraRotation();
    }

    void getCameraRotation()
    {
        if (Input.GetMouseButtonDown(2)) // clicked!
        {
            Debug.Log("basýldý");
            p1 = Input.mousePosition;
        }

        if (Input.GetMouseButton(2)) // keep going
        {
            Debug.Log("basýldý2");

            p2 = Input.mousePosition;
            float dx = (p2 - p1).x * rotationSpeed;
            float dy = (p2 - p1).x * rotationSpeed;

            transform.rotation *= Quaternion.Euler(new Vector3(0, dx, 0));
        }


    }
}
