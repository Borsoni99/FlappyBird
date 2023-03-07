using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{   
    [HideInInspector]
    public float speed;

    private Rigidbody2D myBody;
    
    private SpriteRenderer sr;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(-speed, 0);
    }
        
    
}
