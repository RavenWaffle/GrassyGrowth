using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{

    public List<GameObject> tileList;
    public List<GameObject> desertTiles;
    public List<GameObject> grassTiles;

    private void Start()
    {
        TileUpdate();
    }

    public void TileUpdate()
    {
        foreach (var tile in tileList)
        {
            if (tile.GetComponent<Tile>().tileState == 0 && !tile.GetComponent<Tile>().added)
            {
                tile.GetComponent<Tile>().added = true;
                desertTiles.Add(this.gameObject);
            }
            else if (tile.GetComponent<Tile>().tileState == 1 && !tile.GetComponent<Tile>().added)
            {
                tile.GetComponent<Tile>().added = true;
                grassTiles.Add(this.gameObject);
            }
        }
    }
    
}
