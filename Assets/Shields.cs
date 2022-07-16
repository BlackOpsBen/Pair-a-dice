using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
    [SerializeField] private int shieldStatIndex = 5;

    private int currentShields = 0;

    public void DamageShields()
    {
        currentShields--;
    }

    public bool GetHasShields()
    {
        return currentShields > 0;
    }
}
