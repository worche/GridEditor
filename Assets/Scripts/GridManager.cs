using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int minRowCol = 3;

    [SerializeField] int maxRowCol = 7;

    [Range(3, 7)]
    [SerializeField] int startRow = 3;

    [Range(3, 7)]
    [SerializeField] int startCol = 7;

    [SerializeField] GameObject circlePrefab;

    int rows = 3;

    int cols = 3;

    [SerializeField] Vector2 gridSize;

    List<GameObject> circles;

    Vector2 cellSize;
    Vector2 circleScale;

    Vector2 gridOffset;

    // Use this for initialization
    void Start()
    {
        rows = startRow;
        cols = startCol;

        circles = new List<GameObject>();
        GenerateGrid();
    }

    void GenerateGrid()
    {
        ClearCircles();

        Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y / (float)rows);

        float circleScaleMax = Mathf.Min(newCellSize.x / 1.2f, newCellSize.y / 1.2f);

        circleScale.x = circleScaleMax;
        circleScale.y = circleScaleMax;

        cellSize = newCellSize;

        gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
        gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;



        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Vector2 pos = new Vector2(col * cellSize.x + gridOffset.x, row * cellSize.y + gridOffset.y);
                GameObject circle = Instantiate(circlePrefab, pos, Quaternion.identity, this.transform);

                circle.transform.localScale = circleScale;

                circles.Add(circle);
            }
        }
    }


    public void RowsAdd()
    {
        if (rows >= maxRowCol || Mathf.Abs(rows - cols) > 3)
            return;

        rows++;
        GenerateGrid();
    }
    public void ColsAdd()
    {
        if (cols >= maxRowCol || Mathf.Abs(rows - cols) > 3)
            return;

        cols++;
        GenerateGrid();
    }
    public void ColsSub()
    {
        if (cols <= minRowCol)
            return;

        cols--;
        GenerateGrid();
    }
    public void RowsSub()
    {
        if (rows <= minRowCol)
            return;

        rows--;
        GenerateGrid();
    }
    void ClearCircles()
    {
        if (circles == null)
            return;

        foreach (GameObject item in circles)
        {
            Destroy(item);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridSize);
    }
}
