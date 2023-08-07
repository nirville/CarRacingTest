using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    public WheelCollider LeftFront_WC, LeftRear_WC;
    public WheelCollider rightFront_WC, rightRear_WC;

    public Transform LeftFront_T, LeftRear_T;
    public Transform rightFront_T, rightRear_T;

    public float maxSteerAngle = 30;
    public float motorForce = 50;
    public float brakeForce = 10;

    private bool isBraking = false;


    public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            isBraking = true;
        else if (Input.GetKeyUp(KeyCode.Space))
            isBraking = false;
    }

    public void Steer()
    {
        steeringAngle = maxSteerAngle * horizontalInput;
        LeftFront_WC.steerAngle = steeringAngle;
        rightFront_WC.steerAngle = steeringAngle;
    }

    public void Accelerate()
    {
        LeftFront_WC.motorTorque = verticalInput * motorForce;
        rightFront_WC.motorTorque = verticalInput * motorForce;
        //LeftRear_WC.motorTorque = verticalInput * motorForce;
        //rightRear_WC.motorTorque = verticalInput * motorForce;
    }

    public void Braking()
    {
         var brakeConstant = isBraking ? 100 : 0;

        LeftFront_WC.brakeTorque = brakeConstant * brakeForce;
        rightFront_WC.brakeTorque = brakeConstant * brakeForce;
        LeftRear_WC.brakeTorque = brakeConstant * brakeForce;
        rightRear_WC.brakeTorque = brakeConstant * brakeForce;
    }    


    private void UpdateWheelPoses()
    {
        UpdateWheelPose(LeftFront_WC, LeftFront_T);
        UpdateWheelPose(LeftRear_WC, LeftRear_T);
        UpdateWheelPose(rightFront_WC, rightFront_T);
        UpdateWheelPose(rightRear_WC, rightRear_T);
    }

    private void UpdateWheelPose(WheelCollider wheelCollider, Transform  transform)
    {
        var pos = transform.position;
        var rot = transform.rotation;
        wheelCollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }

    private void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Steer();
        Accelerate();
        Braking();
        UpdateWheelPoses();
    }
}
