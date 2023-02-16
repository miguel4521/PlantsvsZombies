using System;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Zombie Zombie;
    private bool walkingToEnemy = true;
    public float cooldown;
    private GridCell gridCell;
    
    private void Update()
    {
        if (walkingToEnemy)
        {
            gameObject.transform.position += new Vector3(0, 0, Zombie.Speed);
        }
        else
        {
            if (cooldown > 0)
                cooldown -= Time.deltaTime;
            else
            {
                gridCell.getPlantClass().Health -= Zombie.Damage;
                cooldown = Zombie.AttackCooldown;
                if (gridCell.getPlantClass().Health <= 0)
                {
                    Destroy(gridCell.getPlantObj().gameObject);
                    gridCell.isOccupied = false;
                    walkingToEnemy = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collidedObject = collision.gameObject;
        if (collision.gameObject.layer == 8)
        {
            gridCell = collidedObject.GetComponent<GridCell>();
            // Removes zombie state from cell
            if (gridCell.getCol() > 0)
                GameGrid.gameGrid[gridCell.getRow(), gridCell.getCol() - 1].containsZombie = false;
            Physics.IgnoreCollision(collidedObject.GetComponent<Collider>(), GetComponent<Collider>());
            gridCell.containsZombie = true;
            if (gridCell.isOccupied)
                walkingToEnemy = false;
        }

        if (collision.gameObject.name == "PeaPellet")
        {
            Zombie.Health -= 20;
            Destroy(collision.gameObject);
            if (Zombie.Health <= 0)
            {
                GridCell[,] array = GameGrid.gameGrid;
                for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
                {
                    for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                    {
                        if (array[i, j].containsZombie)
                        {
                            array[i, j].containsZombie = false;
                            Destroy(gameObject);
                            return;
                        }
                    }
                }
            }
        }
    }
}