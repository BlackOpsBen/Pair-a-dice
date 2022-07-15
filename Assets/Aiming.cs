using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aiming : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float yawForce = 10.0f;

    [SerializeField] private float yawResponsiveness = 10.0f;

    private Vector2 aimInput;

    private float currentYawMagnitude = 0.0f; // 0-1

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        aimInput = context.ReadValue<Vector2>();

        if (aimInput.sqrMagnitude > 1.0f)
        {
            aimInput.Normalize();
        }
    }

    private void Update()
    {
        currentYawMagnitude = Mathf.Lerp(currentYawMagnitude, aimInput.x, Time.deltaTime * yawResponsiveness);

        //Debug.Log("currentYawMagnitude: " + currentYawMagnitude);
    }

    private void FixedUpdate()
    {
        Vector3 torque = new Vector3(0.0f, yawForce * currentYawMagnitude, 0.0f);
        Quaternion deltaRotation = Quaternion.Euler(torque * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
