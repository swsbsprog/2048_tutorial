using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Array2DEditor
{
    [System.Serializable]
    public class Array2DTile : Array2D<Tile>
    {
        [SerializeField]
        CellRowTile[] cells = new CellRowTile[Consts.defaultGridSize];

        protected override CellRow<Tile> GetCellRow(int idx)
        {
            return cells[idx];
        }
    }
}