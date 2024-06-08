using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TilesManager : MonoBehaviour
{

    public List<GameObject> tileList = new List<GameObject>();
    public List<GameObject> desertTiles = new List<GameObject>();
    public List<GameObject> grassTiles = new List<GameObject>();
    
    public GameObject spawnPoint;
    [SerializeField] public int maxEnemiesPerWave;
    [SerializeField] public int enemiesToKill;
    [SerializeField] private int currentWave;
    [SerializeField] private float timeTillNextWave;

    private int rand;
    private float timeLeft;
    private bool updatedList = false;

    private bool countdownWave = false;

    private void Start()
    {
        timeLeft = timeTillNextWave;
    }

    private void Update()
    {
        if (!updatedList)
        {
            TileUpdate();
        }
        if(!countdownWave)
            StartCoroutine(Wave());
        if (enemiesToKill <= 0)
        {
            countdownWave = true;
        }

        //Debug.Log(enemiesToKill);
    }

    private IEnumerator Wave()
    {
        if (enemiesToKill <= 0)
        {
            countdownWave = true;
            yield return new WaitForSeconds(timeTillNextWave);
                currentWave++;
                countdownWave = false;
                for (int i = 0; i < currentWave; i++)
                {
                    SpawnerSpawn();
                }

                enemiesToKill = maxEnemiesPerWave * currentWave;
                timeLeft = timeTillNextWave;
            
        }
    }

    public void TileUpdate()
    {
        foreach (var tile in tileList)
        {
            if (tile.GetComponent<Tile>().tileState == 0)
            {
                desertTiles.Add(tile);
            }
            else if (tile.GetComponent<Tile>().tileState == 1)
            {
                grassTiles.Add(tile);
            }
        }

        updatedList = true;
    }
    
    private void SpawnerSpawn()
    {
        rand = Random.Range(0, desertTiles.Count);
        //Instantiate(enemies[Random.Range(0, enemies.Length)], desertTiles[Random.Range(0, desertTiles.Count)].transform.position, transform.rotation);
        Instantiate(spawnPoint,desertTiles[rand].transform);
        desertTiles[rand].GetComponent<Tile>().occupied = true;
        spawnPoint.GetComponent<EnemySpawner>().currentTile = rand;
    }
    
}
