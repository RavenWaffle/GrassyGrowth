using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Tooltip("ID: 0=Desert, 1=Grass, 2=Tower")]
    public int tileState = 0;

    [SerializeField] private Material desert;
    [SerializeField] private Material grass;
    [SerializeField] private Material tower;
    
    private TilesManager tilesManager;

    private void Start()
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
        else if (tileState == 2)
        {
            this.GetComponent<MeshRenderer>().material = tower;
        }
    }
}
