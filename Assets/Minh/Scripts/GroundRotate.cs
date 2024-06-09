using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundRotate : MonoBehaviour
{
    private void Awake()
    {
        this.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
    }
}
