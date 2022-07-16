using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInitializer : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Aiming aiming;

    public void InitializeShip(ShipStats stats)
    {
        movement.SetDiceMultipliers(stats.speed, stats.strafing);
        aiming.SetTurnDice(stats.turning);
    }
}
