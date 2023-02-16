using UnityEngine;

public class GridCell : MonoBehaviour
{
    private float posX, posZ;
    private int row, col;

    // Reference to the game object placed in this cell
    public bool isOccupied, containsZombie;
    private PlantController plantObj;
    private Plant plantClass;
    

    // Set the position of this grid cell
    public void setPosition(int r, int c, float sqSize)
    {
        posX = r * sqSize;
        posZ = c * sqSize;
        row = r;
        col = c;
    }

    public PlantController getPlantObj()
    {
        return plantObj;
    }

    public void setPlantObj(PlantController plant)
    {
        plantObj = plant;
    }

    public Plant getPlantClass()
    {
        return plantClass;
    }

    public void setPlantClass(Plant plant)
    {
        plantClass = plant;
    }

    public int getRow()
    {
        return row;
    }

    public int getCol()
    {
        return col;
    }
    
    // Get the position of the grid space on the grid
    public Vector3 getPosition()
    {
        return new Vector3(posX, 0, posZ);
    }
}