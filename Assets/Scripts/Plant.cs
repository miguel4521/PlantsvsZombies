using System;
using UnityEngine;

public class Plant
{
    public String Name { get; set; }
    public String ProjectileName { get; set; }
    public float Health { get; set; }
    public float Timer { get; set; }
    public float MaxAttackSpeed { get; set; }
    public float MinAttackSpeed { get; set; }
    public int Price { get; set; }
    public Sprite Sprite { get; set; }
    public PlantController Model { get; set; }
    public float ProjectileForce { get; set; }
    public float ProjectileUpwardForce { get; set; }
    public int ProjectileLifeTime { get; set; }
    public Vector3 ProjectileOffset { get; set; }

}

public class PeaShooter : Plant
{
    public PeaShooter(Sprite peaSprite, PlantController peaObject)
    {
        Name = "Pea Shooter";
        ProjectileName = "PeaPellet";
        Health = 300;
        Timer = 5f;
        Price = 100;
        MaxAttackSpeed = 1.6f;
        MinAttackSpeed = 1.4f;
        Sprite = peaSprite;
        Model = peaObject;
        ProjectileForce = 20f;
        ProjectileUpwardForce = 0f;
        ProjectileLifeTime = 5;
        ProjectileOffset = new Vector3(0.4f, 1.68f, -1.8f);
    }
}

public class Sunflower : Plant
{
    public Sunflower(Sprite sunSprite, PlantController sunObject)
    {
        Name = "Sunflower";
        ProjectileName = "Sun";
        Price = 50;
        Timer = 5f;
        MaxAttackSpeed = 30f;
        MinAttackSpeed = 20f;
        Sprite = sunSprite;
        Model = sunObject;
        ProjectileForce = 0f;
        ProjectileUpwardForce = 1f;
        ProjectileLifeTime = 15;
        ProjectileOffset = new Vector3(0, 0.8f, 0);
    }
}