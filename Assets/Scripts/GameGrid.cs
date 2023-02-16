using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField]
    private float cellSize;

    [SerializeField]
    private GridCell gridCellPrefab;
    public static readonly GridCell[,] gameGrid = new GridCell[5, 9];

    // Start is called before the first frame update
    void Start()
    {
        int rows = 5;
        int cols = 9;
        createGrid(rows, cols);
    }

    private void createGrid(int rows, int cols)
    {
        if (gridCellPrefab == null)
        {
            Debug.LogError("Cell prefab not selected");
            return;
        }

        // Make the grid
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                gameGrid[row, col] = Instantiate(
                    gridCellPrefab,
                    new Vector3(row * cellSize, 0, col * cellSize),
                    Quaternion.identity
                );
                GridCell cell = gameGrid[row, col];
                cell.GetComponent<GridCell>().setPosition(row, col, cellSize);
                cell.transform.parent = transform;
                cell.name = $"Cell (Row:{row}, Col:{col})";
            }
        }
    }
}
