using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToCamera : MonoBehaviour
{
    public Transform target; 
    Camera cam;

    void Start() 
    { 
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        target.position = transform.position;
        target.rotation = Quaternion.Euler(target.rotation.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z); 
    }

}
