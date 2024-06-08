using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private bool waterResource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (waterResource)
            {
                other.gameObject.GetComponent<PlayerResource>().currentWaterResource++;
                Destroy(this.gameObject);
            }
            else
            {
                other.gameObject.GetComponent<PlayerResource>().currentSeedResource++;
                Destroy(this.gameObject);
            }
        }
    }
}
