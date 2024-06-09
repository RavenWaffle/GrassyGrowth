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
        Vector3 randomVector = new Vector3(1, 0f, 1);
        int x = Random.Range(-2, 2);
        int z = Random.Range(-2, 2);
        randomVector.Scale(new Vector3(Mathf.Cos(x * Mathf.PI), 0, Mathf.Cos(z * Mathf.PI)));
        Instantiate(resource[GetRandomSpawn()], this.transform.position + (randomVector.normalized * 2f) + new Vector3(0, 1f, 0)  , resource[GetRandomSpawn()].transform.rotation);
        counting = true;
        yield return new WaitForSeconds(timeBetweenSpawns);
        counting = false;
        timeToSpawns = timeBetweenSpawns;
    }
}
