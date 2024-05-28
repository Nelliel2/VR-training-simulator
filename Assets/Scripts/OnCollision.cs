using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    
    public GameObject ObjectCollision = null;
    public bool isCollisioning { get; private set; }

    void Start()
    {
        isCollisioning = false;
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.body.gameObject == ObjectCollision) 
        {
            print("Collision detected " + ObjectCollision);
            isCollisioning = true;
        }
    }
}
