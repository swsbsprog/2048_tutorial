using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileSpawner : MonoBehaviour
{
    public Tile baseTile;
    public int seed = 16;
    void Start()
    {
        if(seed != 0)
            Random.InitState(seed);
        Spawn();
        Spawn();
    }

    private void Spawn()
    {
        var newTile = Instantiate(baseTile);
        Vector2Int spawnPos;
        do
        {
            spawnPos = new Vector2Int(Random.Range(0, 4)
            , Random.Range(0, 4));
        } while (TileManager.instance.tiles.GetCell(spawnPos.x, spawnPos.y) != null);

        newTile.SetPosition(spawnPos);
        newTile.SetNumber(2);
    }
}
