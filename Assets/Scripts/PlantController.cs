using System;
using UnityEngine;
using Random = System.Random;

public class PlantController : MonoBehaviour
{
    public Plant Plant;
    public bool placed;
    public float cooldown;
    public ProjectileHandler projectilePrefab;
    public int row, col;

    private void Update()
    {
        if (!placed)
            return;
        if (cooldown > 0)
            cooldown -= Time.deltaTime;
        else
        {
            var enemyFound = false;
            for (var iCol = 0; iCol < 9; iCol++)
            {
                if (!GameGrid.gameGrid[row, iCol].containsZombie || col < iCol) continue;
                enemyFound = true;
                break;
            }
            if (enemyFound || Plant.Name == "Sunflower")
            {
                var projectile = Instantiate(projectilePrefab, transform.position + Plant.ProjectileOffset,
                    Quaternion.identity);
                projectile.Plant = Plant;
                projectile.name = Plant.ProjectileName;
                cooldown = getRandomCooldown(Plant);
            }
        }
    }

    private float getRandomCooldown(Plant plant)
    {
        var rnd = new Random();
        return (float) (rnd.NextDouble() * plant.MaxAttackSpeed) + plant.MinAttackSpeed;
    }
}