using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResourceGen : MonoBehaviour
{
    [Tooltip("1=water, 2=wood")]
    public int resourceType;

    public GameObject[] resource;
    public float[] percentage;
    
    [SerializeField] public float timeBetweenSpawns;
    [SerializeField] public float timeToSpawns;
    private bool counting = false;
        
    private Queue<IEnumerator> coroutineQueue = new Queue<IEnumerator> ();

    private void Start()
    {
        StartCoroutine(CoroutineCoordinator());
    }

    public int GetRandomSpawn()
    {
        float random = Random.Range(0f, 1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i < percentage.Length; i++)
        {
            total += percentage[i];
        }

        for (int i = 0; i < resource.Length; i++)
        {
            if (percentage[i] / total + numForAdding >= random)
            {
                //Debug.Log(i);
                return i;
            }
            else
            {
                numForAdding += percentage[i] / total;
            }
                        
        }
                

        return 0;
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

    private void Update()
    {
        coroutineQueue.Enqueue(SpawnResource());
        if(counting)
            timeToSpawns -= Time.deltaTime;
    }

    private IEnumerator SpawnResource()
    {
        Instantiate(resource[GetRandomSpawn()], new Vector3( this.transform.position.x + Random.Range(-2f, 2f), 2, this.transform.position.z + Random.Range(-2f, 2f)), resource[GetRandomSpawn()].transform.rotation);
        counting = true;
        yield return new WaitForSeconds(timeBetweenSpawns);
        counting = false;
        timeToSpawns = timeBetweenSpawns;
    }
}
