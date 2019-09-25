using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [Header("Rows Cols Settings")]
    [SerializeField] int minRow = 3;
    [SerializeField] int minCol = 3;

    [SerializeField] int maxRow = 7;
    [SerializeField] int maxCol = 7;

    [Header("Start Settings")]
    [Range(3, 7)]
    [SerializeField] int startRow = 3;

    [Range(3, 7)]
    [SerializeField] int startCol = 7;

    [SerializeField] Vector2 gridSize;

    [SerializeField] GameObject circlePrefab;

    int rows = 3;

    int cols = 3;

    

    [HideInInspector]
    public List<GameObject> circles;

    Vector2 cellSize;
    Vector2 circleScale;

    Vector2 gridOffset;

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

        Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y / (float)rows); //grid genişliğine göre hücre alanlarını hesaplar

        float circleScaleMax = Mathf.Min(newCellSize.x / 1.2f, newCellSize.y / 1.2f); // hücrelerde bulunacak objelerin büyüklüklerinin  hesabı
        //oluşan obje hücre boyutunun yüzde 80 büyüklüğünde bir scale ile oluşuyor. Bu oran değişebilir. Şuanda sabit. 
        //objemizin x,y scalenin eşit olması gerektiği için x ve y değerlerinden küçük olanı scale'imiz kabul ediyoruz.

        circleScale.x = circleScaleMax;
        circleScale.y = circleScaleMax;

        cellSize = newCellSize;

        gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2; // grid büyüklüğümüze tam oturması offset değerini hesaplıyoruz.
        gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Vector2 pos = new Vector2(
                    col * cellSize.x + gridOffset.x+ transform.position.x, 
                    row * cellSize.y + gridOffset.y+transform.position.y);


                GameObject circle = Instantiate(circlePrefab, pos, Quaternion.identity, this.transform);

                circle.transform.localScale = circleScale;

                circles.Add(circle);
            }
        }
    }


    public void RowsAdd()
    {
        if (rows >= maxRow )
            return;

        rows++;
        GenerateGrid();
    }
    public void ColsAdd()
    {
        if (cols >= maxCol )
            return;

        cols++;
        GenerateGrid();
    }
    public void ColsSub()
    {
        if (cols <= minCol)
            return;

        cols--;
        GenerateGrid();
    }
    public void RowsSub()
    {
        if (rows <= minRow)
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
        circles.Clear();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridSize);
    }
}
