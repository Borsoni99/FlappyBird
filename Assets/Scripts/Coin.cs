using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;

    public void Collect(GameObject collectedItem)
    {
        Player.coins += 1;
        Destroy(gameObject);
    }

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        myBody.velocity = new Vector2(-speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect(gameObject);       
    }
}
