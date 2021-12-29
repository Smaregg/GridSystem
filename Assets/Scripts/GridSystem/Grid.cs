using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class Grid
    {
        public Vector3 Position { get { return m_v3Position; } }

        public Grid(Vector3 position, int width, int height, int cellSize)
        {
            m_v3Position = position;
            m_iWidth = width;
            m_iHeight = height;
            m_iCellSize = cellSize;
            m_lsCells = new List<Cell>();
            m_goTileRoot = new GameObject("Grid");

            for (int i = 0; i < m_iWidth; i++)
            {
                for (int j = 0; j < m_iHeight; j++)
                {
                    Cell cell = new Cell(this, m_goTileRoot, new Vector2(i, j), m_iCellSize);
                    m_lsCells.Add(cell);
                }
            }
        }

        public Cell GetCellByWorldPos(Vector3 worldPos)
        {
            Vector3 offset = worldPos - m_goTileRoot.transform.position;
            int pixelX = (int)offset.x / m_iCellSize;
            int pixelY = (int)offset.y / m_iCellSize;
            return GetCellByCoord(pixelX, pixelY);
        }

        public Cell GetCellByCoord(int x, int y)
        {
            for (int i = 0; i < m_lsCells.Count; i++)
            {
                if (m_lsCells[i].Coordinat.x == x && m_lsCells[i].Coordinat.y == y)
                    return m_lsCells[i];
            }
            return null;
        }

        public Vector3 GetWorldPosByCoor(Vector2 coord)
        {
            return GetWorldPosByCoor((int)coord.x, (int)coord.y);
        }

        public Vector3 GetWorldPosByCoor(int x, int y)
        {
            return m_goTileRoot.transform.position + new Vector3(x * m_iCellSize, 0, y * m_iCellSize);
        }

        private Vector3 m_v3Position = Vector3.zero;

        private int m_iWidth = 0;

        private int m_iHeight = 0;

        private int m_iCellSize = 0;

        private List<Cell> m_lsCells = null;

        private GameObject m_goTileRoot = null;
    }
}