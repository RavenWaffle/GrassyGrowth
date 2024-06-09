using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public TilesManager tilesManager;
    public GameObject[] enemies;
    [SerializeField] private float timeBetweenSpawns;
    public int currentTile;
    private int i;
    [SerializeField] private GameObject wood;
    
    
    private Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator> ();
    private void Start()
    {
        tilesManager = GameObject.FindGameObjectWithTag("TileManager").GetComponent<TilesManager>();
        StartCoroutine(CoroutineCoordinator());
    }
    
    IEnumerator CoroutineCoordinator()
    {
        while (true)
        {
            while (coroutineQueue.Count >0)
                yield return StartCoroutine(coroutineQueue.Dequeue());
            yield return null;
        }
    }

    private IEnumerator EnemySpawn()
    {
        if(i < tilesManager.maxEnemiesPerWave)
        {
            i++;
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, transform.rotation);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void Update()
    {
        coroutineQueue.Enqueue(EnemySpawn());
        if (i == tilesManager.maxEnemiesPerWave)
        {
            tilesManager.desertTiles[currentTile].GetComponent<Tile>().occupied = false;
            for (int i = tilesManager.currentWave - 1; i >= 0; i--)
            {
                Instantiate(wood, this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
}
