using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerResource : MonoBehaviour
{
    [SerializeField] private PlayerController pc;
    
    public int currentWaterResource, currentSeedResource, requiredWaterResource, requiredSeedResource;

    public bool usingWater;

    public bool spraying = false;

    private bool canSpray = true;

    [SerializeField] private float animationLength = 0.5f;

    [SerializeField] private GameObject towerHolder, tower;

    [SerializeField] private LayerMask ground;

    [SerializeField] private GameObject towerPrefab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (usingWater)
                usingWater = false;
            else
            {
                usingWater = true;
                towerHolder.SetActive(false);
            }
        }
        handler();
        if(usingWater)
            StartCoroutine(TileCheck());
        else
        {
            TowerPlacement();
        }
    }

    /*
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (usingWater)
                usingWater = false;
            else
            {
                usingWater = true;
                towerHolder.SetActive(false);
            }
        }
    }*/

    private void WaterResourceManagement()
    {
        if (currentWaterResource >= requiredWaterResource)
        {
            currentWaterResource = currentWaterResource - requiredWaterResource;
        }
    }
    private void SeedResourceManagement()
    {
        if (currentSeedResource >= requiredSeedResource)
        {
            currentSeedResource = currentSeedResource - requiredSeedResource;
        }
    }

    void handler()
    {
        if (spraying)
        {
            pc.canMove = false;
            pc.DeadStop();
        }
        else
        {
            pc.canMove = true;
        }
    }
    
    IEnumerator TileCheck()
    {
        if (Input.GetKeyDown(KeyCode.J) && canSpray)
        {
            canSpray = false;
            spraying = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                Debug.Log(hit.collider.gameObject);
                if (hit.collider.gameObject.CompareTag("Tile"))
                {
                    if (usingWater && hit.collider.gameObject.GetComponent<Tile>().tileState == 0 &&
                        currentWaterResource >= requiredWaterResource)
                    {
                        WaterResourceManagement();
                        hit.collider.gameObject.GetComponent<Tile>().tileState++;
                        TilesManager tilesManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TilesManager>();
                        tilesManager.grassTiles.Add(hit.collider.gameObject);
                        tilesManager.desertTiles.Remove(hit.collider.gameObject);
                    }

                    /*else if (!usingWater && hit.collider.gameObject.GetComponent<Tile>().tileState > 0 &&
                             currentSeedResource >= requiredSeedResource)
                    {
                        SeedResourceManagement();
                        hit.collider.gameObject.GetComponent<Tile>().tileState++;

                    }*/
                } 
            } 
            yield return new WaitForSeconds(animationLength);
            spraying = false;
            canSpray = true;
        }
    }

    void TowerPlacement()
    {
        towerHolder.SetActive(true);
        RaycastHit hit;
        if (Physics.Raycast(towerHolder.transform.position, -transform.up, out hit, ground))
        {
            tower.transform.position = hit.collider.gameObject.transform.position;
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (hit.collider.gameObject.GetComponent<Tile>().occupied == false && currentSeedResource >= requiredSeedResource &&hit.collider.gameObject.GetComponent<Tile>().tileState == 1)
                {
                    var newTower = Instantiate(towerPrefab, tower.transform);
                    newTower.transform.parent = hit.collider.gameObject.transform;
                    SeedResourceManagement();
                    hit.collider.gameObject.GetComponent<Tile>().occupied = true;
                }
            }
        }

        
        


    }
}
