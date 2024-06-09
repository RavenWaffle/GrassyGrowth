using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 offset;
    private Vector3 velocity;

    private void Start()
    {
        offset = player.transform.position - this.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(this.transform.position + offset, player.transform.position, ref velocity, 0.5f);
    }
}
