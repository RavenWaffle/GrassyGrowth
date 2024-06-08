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
    private void Update()
    {
        StartCoroutine(TileCheck());
        handler();
    }

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
        if (Input.GetKeyDown(KeyCode.Space) && canSpray)
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
                    }

                    else if (!usingWater && hit.collider.gameObject.GetComponent<Tile>().tileState > 0 &&
                             currentSeedResource >= requiredSeedResource)
                    {
                        SeedResourceManagement();
                        hit.collider.gameObject.GetComponent<Tile>().tileState++;

                    }
                } 
            } 
            yield return new WaitForSeconds(animationLength);
            spraying = false;
            canSpray = true;
        }
    }
}
