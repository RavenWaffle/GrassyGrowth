using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Tooltip("ID: 0=Desert, 1=Grass, 2=FertilizedLand")]
    public int tileState = 0;

    public bool occupied = false;

    //public bool added = false;

    [SerializeField] private GameObject desert;
    [SerializeField] private GameObject grass;
    
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
        {
            grass.SetActive(false);
            desert.SetActive(true);
        }
        else if (tileState == 1)
        {
            desert.SetActive(false);
            grass.SetActive(true);
        }
    }
}
