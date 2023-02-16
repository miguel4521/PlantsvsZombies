using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie
{
    public String Name { get; set; }
    public float Health { get; set; }
    public float AttackCooldown { get; set; }
    public GameObject Model { get; set; }
    public float Speed { get; set; }
    public float Damage { get; set; }
    
}

public class NormalZombie : Zombie
{
    public NormalZombie(GameObject model)
    {
        Name = "NormalZombie";
        Health = 190;
        AttackCooldown = 1.5f;
        Model = model;
        Speed = 0.008f;
        Damage = 100;
    }
}

public class TFZombie : Zombie
{
    public TFZombie(GameObject model)
    {
        Name = "TrafficConeZombie";
        Health = 400;
        AttackCooldown = 2f;
        Model = model;
        Speed = 0.01f;
    }
}
