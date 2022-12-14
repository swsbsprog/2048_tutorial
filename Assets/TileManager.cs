using Array2DEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    public GameClearUI gameClearUI;

    public Array2DTile tiles = new Array2DTile();
    private void Awake() => instance = this;
    float enableMoveTime;
    public void OnMove(Vector2Int direction)
    {
        if (Time.time < enableMoveTime)
            return;
        //print("방향 : "+direction);

        // 모든 타일을 순회 하면서 방향으로 이동하기
        //for (int y = 0; y < 4; y++)
        int[] yArray = (direction == Vector2Int.down) ?
            new int[]{ 3, 2, 1, 0 } : new int[] { 0, 1, 2, 3 };

        int[] xArray = (direction == Vector2Int.left) ?
            new int[] { 3, 2, 1, 0 } : new int[] { 0, 1, 2, 3 };

        // 스폰 되어야 하는 상황 : 움직였다 혹은 합쳐졌다
        bool isClear = false;
        bool needSpawn = false;
        foreach (var y in yArray)
        {
            foreach (var x in xArray)
            {
                // null이 아닐때만 움직이자
                if(tiles.GetCell(x,y) != null)
                {
                    // 방향으로 움직이자.
                    var item = tiles.GetCell(x, y);
                    var nextPos = item.pos + direction;
                    if (IsInArea(nextPos)) // 움직일 수 있는 영역 안에서만 이동 가능(0 ~ 3)
                    {
                        // 움직이는 곳에 타일이 있다면 
                        var nextTile = tiles.GetCell(nextPos.x, nextPos.y);
                        if(nextTile != null ) // 있다면 
                        {
                            if(nextTile.number == item.number)
                            {
                                //  같다면 -> 합친다(이동가능)
                                isClear = isClear || item.SetNumber(item.number * 2);
                                item.SetPosition(nextPos);
                                Destroy(nextTile.gameObject);
                                needSpawn = true;
                            }
                        }
                        else
                        {
                            item.SetPosition(nextPos);
                            needSpawn = true;
                        }
                    }
                }
            }
        }

        if(needSpawn)
        {
            enableMoveTime = Time.time + 0.3f;
            TileSpawner.instance.Spawn();
        } 

        if (isClear)
            gameClearUI.gameObject.SetActive(true);
    }

    private bool IsInArea(Vector2Int pos)
    {
        if(pos.x < 0 || pos.y < 0 || pos.x > 3 || pos.y > 3)
            return false;

        return true;    
    }
}
