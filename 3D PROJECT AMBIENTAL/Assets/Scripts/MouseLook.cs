using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Look")]
    [SerializeField, Range(0, 120)] float downLimit;
    [SerializeField, Range(-120, 0)] float upLimit;

    [SerializeField] float mouseSensitivity = 1000f;
    public Transform playerBody;

    float rotationX = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, upLimit, downLimit);

        transform.localRotation = Quaternion.Euler(rotationX,0,0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
