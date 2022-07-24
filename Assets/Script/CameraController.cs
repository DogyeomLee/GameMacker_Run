using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSenstivity = 10.0f;
    public Transform playerBody;
    public Joystick rightjoystick;

    private float XRotation = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * mouseSenstivity;
        float y = Input.GetAxis("Mouse Y") * mouseSenstivity;

        XRotation -= y;
        XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * x);

        float x1 = rightjoystick.Horizontal;
        float y1 = rightjoystick.Vertical;

        XRotation -= y1;
        XRotation = Mathf.Clamp(XRotation, -90.0f, 90.0f);

        transform.localRotation = Quaternion.Euler(XRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * x1);
    }
}
