using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float controlSens = 100.0f;
    public Transform playerBody;

    private float XRotation = 0.0f;

    public Joystick rightJoystick;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X") * controlSens;
        //float mouseY = Input.GetAxis("Mouse Y") * controlSens;

        float controlX = rightJoystick.Horizontal * controlSens;
        float controlY = rightJoystick.Vertical * controlSens;

        XRotation -= controlY;
        XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * controlX);
    }
}
