using UnityEngine;
using UnityEditor;

namespace Array2DEditor
{
    [CustomPropertyDrawer(typeof(Array2DTile))]
    public class Array2DTileDrawer : Array2DObjectDrawer<Tile>
    {
        protected override Vector2Int GetDefaultCellSizeValue() => new Vector2Int(96, 16);
        protected override object GetCellValue(SerializedProperty cell) => cell.managedReferenceValue;
    }
}
