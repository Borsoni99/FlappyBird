using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private string WALL_TAG = "Wall";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(WALL_TAG))
            Destroy(collision.gameObject);
    }
}
