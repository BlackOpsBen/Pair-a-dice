using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform[] muzzles;

    private bool isShooting = false;

    [SerializeField] private float fireRateBase = 1.0f;

    private int fireRateDice = 1;

    private float shotTimer = 0.0f;

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isShooting = true;
        }
        if (context.canceled)
        {
            isShooting = false;
        }
    }

    private void Update()
    {
        shotTimer += Time.deltaTime;

        if (isShooting)
        {
            float timePerShot = 1.0f / (fireRateBase * fireRateDice);

            if (shotTimer > timePerShot)
            {
                shotTimer = 0.0f;
                PerformShot();
            }
        }
    }

    private void PerformShot()
    {
        Debug.LogWarning("SHOT FIRED!");
    }

    public void SetDice(int result)
    {
        fireRateDice = result;
    }
}
