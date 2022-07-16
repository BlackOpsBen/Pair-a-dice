using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int baseHealth = 1;

    private int currentHealth = 1;

    private Shields shields;

    private void Awake()
    {
        shields = GetComponent<Shields>();
    }

    public void Damage(int amount)
    {
        if ((bool)(shields?.GetHasShields()))
        {
            shields.DamageShields();
        }
        else
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                StartDeath();
            }
        }
    }

    private void StartDeath()
    {
        Debug.LogWarning(gameObject.name + " is dead!");
    }
}
