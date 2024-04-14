using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer renderer;
    private GameObject gameObject;

    public VisibilityObject(Renderer r, GameObject obj) 
    {
        renderer = r;
        gameObject = obj;

    }
    void Start()
    {

    }


    public void Hide()
    {
        renderer.enabled = false;
        Renderer[] lChildRenderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled = false;
        }
    }

    public void Show()
    {
        renderer.enabled = true;
        Renderer[] lChildRenderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
