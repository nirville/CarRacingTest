using UnityEngine;
using System.Collections;

public class FPSCamera : MonoBehaviour
{
    public float speedH = 2f;
    public float speedV = 2f;

    private float yaw = 0;
    private float pitch = 0;

    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
