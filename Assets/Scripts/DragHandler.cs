using UnityEngine;
using UnityEngine.EventSystems;
using Random = System.Random;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private LayerMask gridLayer;
    private GridCell selectedCell;
    private int index;
    private PlantController plant;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Gets which button was dragged
        index = int.Parse(name[4].ToString());
        var selectedPlant = LevelHandler.Plants[index];
        if (selectedPlant == null) return;
        if (selectedPlant.Price > LevelHandler.SunCount)
            plant = null;
        else
        {
            plant = Instantiate(selectedPlant.Model, new Vector3(100, 100, 100), Quaternion.identity);
            plant.transform.Rotate(0, 180, 0);
            plant.name = selectedPlant.Name;
            GridCell[,] array = GameGrid.gameGrid;
            for (int i = 0; i < array.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < array.GetUpperBound(1) + 1; j++)
                {
                    if (!array[i, j].isOccupied)
                        array[i, j].GetComponentInChildren<SpriteRenderer>().material.color = new Color(245, 233, 115);
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Gets the cell that is being hovered over
        selectedCell = getCellOnMouse();
        // Places it in the cell that is being hovered over
        if (selectedCell != null && !selectedCell.isOccupied && !selectedCell.containsZombie && plant != null)
            plant.transform.position = selectedCell.getPosition() + new Vector3(0f, 1f, 0f);
        if (selectedCell == null && plant != null)
            plant.transform.position = new Vector3(100, 100, 100);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (plant == null) return;
        // Remove plant if placed off of grid
        if (selectedCell == null || selectedCell.containsZombie)
            Destroy(plant.gameObject);
        else
        {
            selectedCell.setPlantObj(plant);
            selectedCell.isOccupied = true;
            plant.Plant = LevelHandler.Plants[index];
            selectedCell.setPlantClass(plant.Plant);
            plant.placed = true;
            plant.row = selectedCell.getRow();
            plant.col = selectedCell.getCol();
            plant.cooldown = getRandomCooldown(plant.Plant);
            LevelHandler.SunCount -= plant.Plant.Price;
        }
    }

    // Get the cell that the mouse is on
    private GridCell getCellOnMouse()
    {
        if (Camera.main is null) return null;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out RaycastHit hit, gridLayer) ? hit.transform.GetComponent<GridCell>() : null;
    }

    private float getRandomCooldown(Plant plantClass)
    {
        var rnd = new Random();
        return (float) (rnd.NextDouble() * plantClass.MaxAttackSpeed) + plantClass.MinAttackSpeed;
    }
}