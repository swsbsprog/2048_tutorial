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
        print(direction);

        // 모든 타일을 순회 하면서 방향으로 이동하기
        // 움직일 수 있는 영역 안에서만 이동 가능(0 ~ 3)
        // 움직이는 곳에 타일이 있다면 
        //  같다면 -> 합친다(이동가능)
        //  다르다면 이동 불가.
    }
}
