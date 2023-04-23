using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 100f;

    private Camera playerCamera;
    private float verticalRotation = 0f;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movement
        float x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        Vector3 move = transform.right * x + transform.forward * z;
        transform.position += move;

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}