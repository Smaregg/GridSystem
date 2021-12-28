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

        public GameObject TilePrefab = null;

        public float TileSize = 1;

        private static GridPlugin m_instance = null;
    }
}