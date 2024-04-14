using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityObject : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer rd;
    private GameObject gameObj;

    public void setVisibilityObject(Renderer r, GameObject obj) 
    {
        rd = r;
        gameObj = obj;

    }  
    public VisibilityObject(Renderer r, GameObject obj) 
    {
        rd = r;
        gameObj = obj;

    }
    void Start()
    {

    }


    public void Hide()
    {
        rd.enabled = false;
        Renderer[] lChildRenderers = gameObj.GetComponentsInChildren<Renderer>();
        foreach (Renderer lRenderer in lChildRenderers)
        {
            lRenderer.enabled = false;
        }
    }

    public void Show()
    {
        rd.enabled = true;
        Renderer[] lChildRenderers = gameObj.GetComponentsInChildren<Renderer>();
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
