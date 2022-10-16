using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TextMesh textMesh;
    public int number;
    public void SetNumber(int setNumber)
    {
        number = setNumber;
        UpdateText();
    }

    string CoordStr => $"{transform.position.x}," +
        $" {transform.position.y}";
    private void UpdateText()
    {
        textMesh.text = $@"<size=50>{CoordStr}</size>
{number}";
    }
    public Vector2Int pos;
    public void SetPosition(Vector2Int pos)
    {
        this.pos = pos;
        transform.position = new Vector2(pos.x, pos.y);   
        TileManager.instance.tiles.SetCell(pos.x, pos.y, this);
        UpdateText();
    }
}
