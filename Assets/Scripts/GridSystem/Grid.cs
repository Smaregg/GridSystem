using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class Grid
    {
        public Vector3 Position { get { return m_v3Position; } }

        public List<Vector3[]> GetAllEdges()
        {
            List<Vector3[]> allEdges = new List<Vector3[]>();
            for (int i = 0; i < m_iWidth; i++)
                for (int j = 0; j < m_iHeight; j++)
                    allEdges.Add(GetCellEdge(i, j));
            return allEdges;
        }

        public Vector3[] GetCellEdge(int indexX, int indexY)
        {
            Vector3 origin = GetCellWorldPosition(indexX, indexY);
            Vector3[] edges = new Vector3[3];
            edges[0] = origin;
            edges[1] = new Vector3(origin.x + m_iCellSize, origin.y, origin.z);
            edges[2] = new Vector3(origin.x, origin.y, origin.z + m_iCellSize);
            return edges;
        }

        public Vector3 GetCellWorldPosition(int indexX, int indexY)
        {
            return new Vector3(m_v3Position.x + indexX * m_iCellSize, m_v3Position.y, m_v3Position.z + indexY * m_iCellSize);
        }

        public Grid(Vector3 position, int width, int height, int cellSize)
        {
            m_v3Position = position;
            m_iWidth = width;
            m_iHeight = height;
            m_iCellSize = cellSize;
        }

        private Vector3 m_v3Position = Vector3.zero;

        private int m_iWidth = 0;

        private int m_iHeight = 0;

        private int m_iCellSize = 0;
    }
}