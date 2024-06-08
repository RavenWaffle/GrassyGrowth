using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestColorChange : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("colliding");
        if (other.gameObject.CompareTag("Tile"))
        {
            other.gameObject.GetComponent<Tile>().tileState++;
        }
    }
}
