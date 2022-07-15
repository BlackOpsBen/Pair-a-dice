using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float throttleForce = 10.0f;

    private Vector2 moveRawInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveRawInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 force = new Vector3(throttleForce * moveRawInput.x, 0.0f, throttleForce * moveRawInput.y);
        rb.AddRelativeForce(force, ForceMode.Force);
    }
}
