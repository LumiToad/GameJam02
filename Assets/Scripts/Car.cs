using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider backLeft;
    public WheelCollider backRight;

    public float acceleration = 500;
    public float breakForce = 300;
    public float turnAngle = 30;
    public float turnSpeed = 0.1f;

    private float currentAngle = 0;
    public float angleReset = 0.85f;


    public float freezeCooldown;
    private float freezeTimer = 0;

    private void FixedUpdate()
    { 
        if (Input.GetKey(KeyCode.W))
        {
            frontLeft.motorTorque = acceleration;
            frontRight.motorTorque = acceleration;

            frontLeft.brakeTorque = 0;
            frontRight.brakeTorque = 0;
            backLeft.brakeTorque = 0;
            backRight.brakeTorque = 0;
        }
        if (Input.GetKey(KeyCode.S))
        {
            frontLeft.brakeTorque = breakForce;
            frontRight.brakeTorque = breakForce;
            backLeft.brakeTorque = breakForce;
            backRight.brakeTorque = breakForce;
        }

        if (Input.GetKey(KeyCode.A))
        {
            currentAngle = Mathf.Clamp(currentAngle - turnSpeed * Time.fixedDeltaTime, -turnAngle, turnAngle);
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentAngle = Mathf.Clamp(currentAngle + turnSpeed * Time.fixedDeltaTime, -turnAngle, turnAngle);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            frontLeft.motorTorque = -acceleration;
            frontRight.motorTorque = -acceleration;
            backLeft.motorTorque = -acceleration;
            backRight.motorTorque = -acceleration;


            frontLeft.brakeTorque = 0;
            frontRight.brakeTorque = 0;
            backLeft.brakeTorque = 0;
            backRight.brakeTorque = 0;
        }

        frontLeft.steerAngle = currentAngle;
        frontRight.steerAngle = currentAngle;

        currentAngle += (currentAngle < 0.0f) ? angleReset : -angleReset;
    }

    private void Update()
    {
        freezeTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && freezeTimer < 0)
        {
            foreach(var box in FindObjectsOfType<box>())
            {
                freezeTimer = freezeCooldown;
                box.Freeze();
            }
        }
    }
}
