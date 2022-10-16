﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileSpawner : MonoBehaviour
{
    public Tile baseTile;
    void Start()
    {
        Spawn();
        Spawn();
    }

    private void Spawn()
    {
        var newTile = Instantiate(baseTile);
        newTile.SetPosition(
            new Vector2Int(Random.Range(0, 4)
            , Random.Range(0, 4)));
        newTile.SetNumber(2);
    }
}
