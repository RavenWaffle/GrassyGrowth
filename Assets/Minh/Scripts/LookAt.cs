using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private Transform Camera;

    private void Start() => Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

    private void Update() => transform.LookAt(new Vector3(Camera.position.x, transform.position.y, Camera.position.z));
}
