using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    public Tile[,] tiles = new Tile[4,4];
    private void Awake() => instance = this;
    public void OnMove(Vector2Int direction)
    {
        print("방향 : "+direction);

        // 모든 타일을 순회 하면서 방향으로 이동하기
        //for (int y = 0; y < 4; y++)
        int[] yArray = (direction == Vector2Int.down) ?
            new int[]{ 3, 2, 1, 0 } : new int[] { 0, 1, 2, 3 };

        int[] xArray = (direction == Vector2Int.left) ?
            new int[] { 3, 2, 1, 0 } : new int[] { 0, 1, 2, 3 };

        foreach (var y in yArray)
        {
            foreach (var x in xArray)
            {
                // null이 아닐때마 움직이자
                if(tiles[x,y] != null)
                {
                    // 방향으로 움직이자.
                    var item = tiles[x, y];
                    var nextPos = item.pos + direction;
                    if (IsInArea(nextPos)) // 움직일 수 있는 영역 안에서만 이동 가능(0 ~ 3)
                    {
                        // 움직이는 곳에 타일이 있다면 
                        var nextTile = tiles[nextPos.x, nextPos.y];
                        if(nextTile != null ) // 있다면 
                        {
                            if(nextTile.number == item.number)
                            {
                                //  같다면 -> 합친다(이동가능)
                                item.SetNumber(item.number * 2);
                                item.SetPosition(nextPos);
                                Destroy(nextTile.gameObject);
                            }
                            else  //  다르다면 이동 불가.
                            {
                                //item.SetPosition(nextPos);
                            }
                        }
                        else
                        {
                            item.SetPosition(nextPos);
                        }
                    }
                }
            }
        }

    }

    private bool IsInArea(Vector2Int pos)
    {
        if(pos.x < 0 || pos.y < 0 || pos.x > 3 || pos.y > 3)
            return false;

        return true;    
    }
}
