using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour
{
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
