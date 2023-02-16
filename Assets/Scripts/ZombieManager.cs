using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public ZombieController zombiePrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnNewEnemy();
    }

    private void spawnNewEnemy()
    {
        var zombie = Instantiate(zombiePrefab, spawnPoints[0].position, Quaternion.identity);
        zombie.Zombie = new NormalZombie(zombie.gameObject);
        zombie.cooldown = zombie.Zombie.AttackCooldown;
    }
}
