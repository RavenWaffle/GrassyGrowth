using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Tooltip("ID: 0=Desert, 1=Grass")]
    public int tileState = 0;

    public bool occupied = false;

    //public bool added = false;

    [SerializeField] private Material desert;
    [SerializeField] private Material grass;
    
    private TilesManager tilesManager;

    private void Awake()
    {
        tilesManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TilesManager>();
        tilesManager.tileList.Add(this.gameObject);
    }

    private void FixedUpdate()
    {
        TileChange();
    }

    private void TileChange()
    {
        if (tileState == 0)
            this.GetComponent<MeshRenderer>().material = desert;
        else if (tileState == 1)
        {
            this.GetComponent<MeshRenderer>().material = grass;
        }
    }
}
