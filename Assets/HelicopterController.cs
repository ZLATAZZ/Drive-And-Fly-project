using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class HelicopterController : VehicleController
{
    private void FixedUpdate()
    {
        MoveVehicle();
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    // Polymorphism
    public override void MoveVehicle()
    {
        // Apply forward movement in local space
        Vector3 localDirection = new Vector3(0.0f, direction.y, direction.y).normalized;
        transform.Translate(localDirection * speed * Time.deltaTime, Space.Self);

        RotateSubmarine();
    }

    private void RotateSubmarine()
    {
        // Apply rotation in local space based on direction input
        float rotation = direction.x * speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rotation, Space.Self);
    }
}
