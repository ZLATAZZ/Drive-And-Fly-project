using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput playerInput;
    InputController inputController;

    [HideInInspector] public Vector2 direction;
    [HideInInspector] public float currentBrakingForce = 0f;
    public float brakingForce = 300f;


    [SerializeField] private float jumpForce;
    public float acceleratorSpeed;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        inputController = new InputController();
        inputController.Vehicle.Enable();
        inputController.Vehicle.Jump.performed += VehicleJump;
        inputController.Vehicle.Jump.canceled += VehicleJump;
        inputController.Vehicle.Drive.performed += Drive_performed;
        inputController.Vehicle.Accelerate.performed += Accelerate_performed;

    }


    private void FixedUpdate()
    {
        MoveVehicle();
        SpeedUpVehicle();
    }


    private void Accelerate_performed(InputAction.CallbackContext obj)
    {
        SpeedUpVehicle();
        
    }

    private void Drive_performed(InputAction.CallbackContext obj)
    {
        MoveVehicle(obj);
    }

    private void VehicleJump(InputAction.CallbackContext context)
    {
       
        if (context.performed)
        {
            Debug.Log("Brake from Vehicle clsss");
            PressSpace();
        }
        else if(context.canceled) 
        {
            currentBrakingForce = 0.0f;
        }

        
       
    }


    //Encapsulation is applied
    #region
    public virtual void MoveVehicle(InputAction.CallbackContext obj)
    {
        direction = obj.ReadValue<Vector2>().normalized;
        

        rb.AddForce(new Vector3(direction.x, 0.0f, direction.y).normalized * speed, ForceMode.Impulse);
    }

    public virtual void MoveVehicle()
    {
        direction = inputController.Vehicle.Drive.ReadValue<Vector2>().normalized;
        

        rb.AddForce(new Vector3(direction.x, 0.0f, direction.y).normalized * speed, ForceMode.Impulse);
    }
    #endregion

    //Abstraction
    public virtual void PressSpace()
    {
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        currentBrakingForce = brakingForce;
    }
   
    public virtual void SpeedUpVehicle()
    {
        direction.y *= acceleratorSpeed;
        rb.AddForce(new Vector3(direction.x, 0.0f, direction.y).normalized * speed, ForceMode.Impulse);
    }
}

   


