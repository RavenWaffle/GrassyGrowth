using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLookAt : MonoBehaviour
{
    private Transform Camera;

    private void Start() => Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

    private void Update() => transform.LookAt(new Vector3(Camera.position.x, Camera.position.y, Camera.position.z ));
}
