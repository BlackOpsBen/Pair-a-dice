using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 strafeForce;
    [SerializeField] private Vector3 throttleForce;
    [SerializeField] private float defaultThrottleMultiplier = 1.0f;
    [SerializeField] private float brakingThrottleMultiplier = 0.5f;
    [SerializeField] private float boostingThrottleMultiplier = 1.5f;

    private int throttleDice = 1;
    private int strafeDice = 1;

    private float throttleRawInput;
    private float strafeRawInput;

    private float throttleAdjusted;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        throttleAdjusted = 1.0f;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveRawInput = context.ReadValue<Vector2>();
        throttleRawInput = moveRawInput.y;
        strafeRawInput = moveRawInput.x;

        if (throttleRawInput > 0.0f)
        {
            throttleAdjusted = Mathf.Lerp(defaultThrottleMultiplier, boostingThrottleMultiplier, throttleRawInput);
        }
        else
        {
            throttleAdjusted = Mathf.Lerp(defaultThrottleMultiplier, brakingThrottleMultiplier, Mathf.Abs(throttleRawInput));
        }
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(strafeForce * strafeRawInput * strafeDice, ForceMode.Force);
        rb.AddRelativeForce(throttleForce * throttleAdjusted * throttleDice, ForceMode.Force);

        float forwardSpeed = Vector3.Dot(rb.velocity, transform.forward);
        //Debug.Log("Forward speed: " + forwardSpeed);

        
    }

    public void SetDiceMultipliers(int throttleDice, int strafeDice)
    {
        this.throttleDice = throttleDice;
        this.strafeDice = strafeDice;
    }
}
