using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToCamera : MonoBehaviour
{
    public Transform target; Camera cam;
    private bool[] seenScenes;

    void Start() 
    { 
        cam = GetComponent<Camera>();
        seenScenes = GameObject.FindObjectOfType<TaskManager>().seenScenes;
    }

    void Update()
    {
        
        //Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        //Debug.Log("target is " + screenPos.x + " pixels from the left");

    }

}
