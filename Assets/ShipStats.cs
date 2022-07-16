using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats
{
    public int speed;
    public int turning;
    public int strafing;
    public int firePower;
    public int fireRate;
    public int health;

    public ShipStats()
    {
        speed = 1;
        turning = 1;
        strafing = 1;
        firePower = 1;
        fireRate = 1;
        health = 1;
    }

    public ShipStats(int speed, int turning, int strafing, int firePower, int fireRate, int health)
    {
        this.speed = speed;
        this.turning = turning;
        this.strafing = strafing;
        this.firePower = firePower;
        this.fireRate = fireRate;
        this.health = health;
    }
}
