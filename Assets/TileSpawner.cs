using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;
public class TileSpawner : MonoBehaviour
{
    public static TileSpawner instance;
    private void Awake() => instance = this;
    public Tile baseTile;
    public int seed = 16;
    public Ease ease = Ease.OutCubic;
    void Start()
    {
        if(seed != 0)
            Random.InitState(seed);
        Spawn();
        Spawn();
    }

    public void Spawn()
    {
        var newTile = Instantiate(baseTile);
        Vector2Int spawnPos;
        do
        {
            spawnPos = new Vector2Int(Random.Range(0, 4)
            , Random.Range(0, 4));
        } while (TileManager.instance.tiles.GetCell(spawnPos.x, spawnPos.y) != null);

        newTile.transform.localScale = Vector2.one * 0.6f;
        newTile.transform.DOScale(Vector2.one, 0.3f)
            .SetEase(ease).SetLink(newTile.gameObject);
        newTile.SetPosition(spawnPos);
        newTile.SetNumber(2);
    }
}
