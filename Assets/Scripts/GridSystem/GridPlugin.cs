using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class GridPlugin
    {
        public static GridPlugin Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new GridPlugin();
                return m_instance;
            }
        }

        public void SetBuildActive(bool isActive)
        {
            BuildObj.SetActive(isActive);
        }

        public void SetBuildToCell(Cell cell)
        {
            SetBuildActive(true);
            BuildObj.transform.position = grid.GetWorldPosByCoor(cell.Coordinat) + m_v3BuildOffsetTemp;
        }

        public GameObject TilePrefab = null;

        public GameObject BuildObj = null;

        public float TileSize = 1;

        public Grid grid = null;

        private static GridPlugin m_instance = null;

        private Vector3 m_v3BuildOffsetTemp = new Vector3(0.5f, 0, 0.5f);
    }
}