using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class Cell
    {
        public GameObject Tile { get { return m_goTile; } }

        public float CellSize { get { return m_fCellSize; } }

        public Vector2 Coordinat { get { return m_v2Coordinat; } }

        public Cell(Grid grid, GameObject root, Vector2 coordinat, float cellSize)
        {
            m_v2Coordinat = coordinat;
            m_fCellSize = cellSize;
            m_fScale = m_fCellSize / GridPlugin.Instance.TileSize;

            Vector3 offset = new Vector3(m_fCellSize / 2, 0, m_fCellSize / 2);
            Vector3 worldPos = new Vector3(grid.Position.x + m_fCellSize * m_v2Coordinat.x, grid.Position.y, grid.Position.z + m_fCellSize * m_v2Coordinat.y) + offset;
            m_goTile = GameObject.Instantiate(GridPlugin.Instance.TilePrefab);
            m_goTile.transform.localScale = new Vector3(m_fScale, 0, m_fScale);
            m_goTile.transform.position = worldPos;
            m_goTile.transform.SetParent(root.transform);
        }

        private GameObject m_goTile = null;

        private Vector2 m_v2Coordinat = Vector2.zero;

        private float m_fCellSize = 0;

        private float m_fScale = 1;
    }
}