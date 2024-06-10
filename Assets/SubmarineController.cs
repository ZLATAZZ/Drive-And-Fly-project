using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class SubmarineController : VehicleController
{
    private void FixedUpdate()
    {
        if (transform.position.y < 2.0f)
        {
            MoveVehicle();
        }
        else
        {
            // Clamp the Y position to prevent the submarine from rising above 2.0 units
            gameObject.transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
        }
    }

    // Polymorphism
    public override void MoveVehicle()
    {
        // Apply forward movement in local space
        Vector3 localDirection = new Vector3(0.0f, 0.0f, direction.y).normalized;
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
