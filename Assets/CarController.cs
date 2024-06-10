using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;


public class CarController : VehicleController
{
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider backRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider backLeft;

    [SerializeField] private Transform t_frontRight;
    [SerializeField] private Transform t_backRight;
    [SerializeField] private Transform t_frontLeft;
    [SerializeField] private Transform t_backLeft;

    public float acceleration = 500f;
   
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
   
    private float currentTurnAngle = 0f;

    public GameObject customCenterOfMass;
    
    Rigidbody rb;

   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = customCenterOfMass.transform.localPosition;
        GameManager.Instance.LoadChoice();

    }

    private void FixedUpdate()
    {


        

        if (GameManager.Instance.isBack == true && GameManager.Instance.isFront == false)
        {
            currentTurnAngle = maxTurnAngle * direction.x;
            currentAcceleration = acceleration * -direction.y;


            frontRight.motorTorque = currentAcceleration;
            frontLeft.motorTorque = currentAcceleration;


            frontRight.brakeTorque = currentBrakingForce;
            backRight.brakeTorque = currentBrakingForce;
            frontLeft.brakeTorque = currentBrakingForce;
            backLeft.brakeTorque = currentBrakingForce;
            backRight.steerAngle = -currentTurnAngle;
            backLeft.steerAngle = -currentTurnAngle;
            Debug.Log("Is back");
        }
        if(GameManager.Instance.isFront == true && GameManager.Instance.isBack == false)
        {
            currentTurnAngle = maxTurnAngle * direction.x;
            currentAcceleration = acceleration * -direction.y;


            frontRight.motorTorque = currentAcceleration;
            frontLeft.motorTorque = currentAcceleration;


            frontRight.brakeTorque = currentBrakingForce;
            backRight.brakeTorque = currentBrakingForce;
            frontLeft.brakeTorque = currentBrakingForce;
            backLeft.brakeTorque = currentBrakingForce;
            frontRight.steerAngle = currentTurnAngle;
            frontLeft.steerAngle = currentTurnAngle;
            Debug.Log("Is front");
        }
        

        UpdateWheel(frontRight, t_frontRight);
        UpdateWheel(frontLeft, t_frontLeft);
        UpdateWheel(backLeft, t_backLeft);
        UpdateWheel(backRight, t_backRight);
    }

    private void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion quaternion;

        col.GetWorldPose(out position, out quaternion);

        trans.position = position;
        trans.rotation = quaternion;
    }

}
