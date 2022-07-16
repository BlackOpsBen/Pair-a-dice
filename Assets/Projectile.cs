using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    [SerializeField] private Rigidbody rb;

    public void Reset(Transform shipTransform, Vector3 shipVelocity)
    {
        rb.position = shipTransform.position;
        rb.rotation = shipTransform.rotation;
        Vector3 newVelocity = shipVelocity + (shipTransform.forward * speed);
        Debug.Log("New Velocity: " + newVelocity);
        rb.velocity = newVelocity;
    }
}
