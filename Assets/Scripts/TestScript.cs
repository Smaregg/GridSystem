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

    #region 生命周期
    private void Start()
    {
        m_grid = new GridSystem.Grid(GridPosition, GridX, GridY, CellSize);
    }

    private void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Vector3 rightUp = new Vector3(GridPosition.x + GridX * CellSize, GridPosition.y, GridPosition.z);
        Vector3 leftDown = new Vector3(GridPosition.x, GridPosition.y, GridPosition.z + GridY * CellSize);
        Vector3 rightDown = new Vector3(GridPosition.x + GridX * CellSize, GridPosition.y, GridPosition.z + GridY * CellSize);
        Gizmos.DrawLine(GridPosition, rightUp);
        Gizmos.DrawLine(GridPosition, leftDown);
        Gizmos.DrawLine(rightUp, rightDown);
        Gizmos.DrawLine(leftDown, rightDown);

        if (m_grid != null)
        {
            List<Vector3[]> gridEdges = m_grid.GetAllEdges();
            Vector3 origin = Vector3.zero;
            Vector3 originRight = Vector3.zero;
            Vector3 originDown = Vector3.zero;
            for (int i = 0; i < gridEdges.Count; i++)
            {
                origin = gridEdges[i][0];
                originRight = gridEdges[i][1];
                originDown = gridEdges[i][2];
                Gizmos.DrawLine(origin, originRight);
                Gizmos.DrawLine(origin, originDown);
            }
        }
    }
    #endregion

    private GridSystem.Grid m_grid = null;
}
