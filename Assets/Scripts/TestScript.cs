using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class TestScript : MonoBehaviour
{
    public Vector3 GridPosition = Vector3.zero;

    public int GridX = 0;

    public int GridY = 0;

    public int CellSize = 0;

    public GameObject TilePrefab = null;

    public float TileSize = 1;

    #region 生命周期
    private void Start()
    {
        GridPlugin.Instance.TilePrefab = TilePrefab;
        GridPlugin.Instance.TileSize = TileSize;
        m_grid = new GridSystem.Grid(GridPosition, GridX, GridY, CellSize);
    }

    private void Update()
    {
        
    }
    #endregion

    private GridSystem.Grid m_grid = null;
}
