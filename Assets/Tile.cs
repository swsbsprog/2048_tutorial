using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TextMesh textMesh;
    public int number;
    public Gradient gradient;
    public int mergeCount = 0;
    public const float MaxMergeCount = 5;
    public void SetNumber(int setNumber)
    {
        number = setNumber;
        Color color = gradient.Evaluate(mergeCount / MaxMergeCount);
        GetComponent<SpriteRenderer>().color = color;
        UpdateText();
        mergeCount++;
        if (mergeCount == MaxMergeCount)
            Debug.LogWarning("게임 클리어");
    }

    string CoordStr => $"{pos.x} ,{pos.y}";
    private void UpdateText()
    {
        textMesh.text = $@"<size=50>{CoordStr}</size>
{number}";
    }
    public Vector2Int pos = new Vector2Int(-1,-1);
    public void SetPosition(Vector2Int pos)
    {
        bool isInitPosition = this.pos.x == -1;
        if(this.pos.x >= 0)
            TileManager.instance.tiles.SetCell(this.pos.x, this.pos.y, null);

        this.pos = pos;
        TileManager.instance.tiles.SetCell(pos.x, pos.y, this);
        if (isInitPosition) // 애니메이션 없이 위치 설정
            transform.position = new Vector2(pos.x, pos.y);
        else
            transform.DOMove(new Vector2(pos.x, pos.y), 0.3f)
            .SetLink(gameObject);
        UpdateText();
    }
}
