using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    private MuzzleFlashes muzzleFlashes;

    private Rigidbody rb; // Used to know what velocity to give to projectiles.

    [SerializeField] private ProjectilePool laserPool;
    
    private bool isShooting = false;

    [SerializeField] private float fireRateBase = 1.0f;

    [SerializeField] private int firePowerStatIndex = 3;
    [SerializeField] private int fireRateStatIndex = 4;

    private float shotTimer = 0.0f;

    private void Awake()
    {
        muzzleFlashes = GetComponent<MuzzleFlashes>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        shotTimer += Time.deltaTime;

        if (isShooting)
        {
            float timePerShot = 1.0f / (fireRateBase * fireRateStatIndex);

            if (shotTimer > timePerShot)
            {
                shotTimer = 0.0f;
                PerformShot();
            }
        }
    }

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

    private void PerformShot()
    {
        Transform muzzle = muzzleFlashes.GetAndUseNextMuzzle();

        Projectile laser = laserPool.GetNextPooledProjectile();

        laser.Reset(transform, rb.velocity);
    }

    public void SetDice(int result)
    {
        fireRateStatIndex = result;
    }
}
