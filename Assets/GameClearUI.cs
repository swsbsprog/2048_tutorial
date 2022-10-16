using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    public Text pointText;
    void Start()
    {
        var tiles = TileManager.instance.tiles.GetCells();
        int[] scoreCount = new int[6];   
        foreach(var tile in tiles)
        {
            if(tile != null)
                scoreCount[tile.mergeCount - 1]++;
        }
        StringBuilder scoreSB = new();
        for (int i = 0; i < scoreCount.Length; i++)
        {
            scoreSB.AppendLine($": {scoreCount[i]}");
        }

        pointText.text = scoreSB.ToString();
    }
}
