using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR.Extras;


public class ActToPointer : MonoBehaviour
{
    static SteamVR_LaserPointer laserPointer = null;


    // Start is called before the first frame update
    void Start()
    {
        // We need to find the laser pointer which we expect attached to our right hand:
        // NOTE: would be better to defend against missing SteamVR_LaserPointer component
        laserPointer = GameObject.Find("RightHand").GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;

        // We need to find the speaking component. This should be attached to our GameObject
        // (because in this specific example use case, we are using the pointer click to
        // our character speaking)
        // NOTE: would be better to defend against missing Speaking component

    }


    public static void PointerInside(object sender, PointerEventArgs e)
    {
        Debug.Log("PointerInside: " + e.target.name);

        switch (e.target.name)
        {
            case "Bottom":
                laserPointer.color = Color.yellow;
                break;
        }
    }

    public static void PointerOutside(object sender, PointerEventArgs e)
    {
        //Debug.Log("PointerOutside: " + e.target.name);

        switch (e.target.name)
        {
            case "Bottom":
                laserPointer.color = Color.black;
                break;
        }
    }

    public static void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log("PointerClick: " + e.target.name);

        switch (e.target.name)
        {
            //WoodPlanks
            case "Bottom":
                laserPointer.color = Color.white;
                break;
        }

    }
}
