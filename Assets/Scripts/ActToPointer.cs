using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;



public class ActToPointer : MonoBehaviour
{
    static SteamVR_LaserPointer laserPointer = null;
    SteamVR_Action_Boolean TurnOnLaserPointer;
    

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
//    void Update()
//    {
 //       if (TurnOnLaserPointer.active)
 //       {
 //           GameObject.Find("RightHand").GetComponent<SteamVR_LaserPointer>().active = false;
 //       }
 //       else {
 //           GameObject.Find("RightHand").GetComponent<SteamVR_LaserPointer>().active = true;
 //       }
 //   }

        public static void PointerInside(object sender, PointerEventArgs e)
    {
        Debug.Log("PointerInside: " + e.target.name);


        switch (e.target.name)
        {
            case "WoodPlanksBottom":
                laserPointer.color = Color.yellow;
                break;
            case "WoodPlanksTop":
                laserPointer.color = Color.yellow;
                break;
            case "WoodPlanksRopes":
                laserPointer.color = Color.yellow;
                break;            
            case "WoodPlanksFabric":
                laserPointer.color = Color.yellow;
                break;
            case "CementToFall":
                laserPointer.color = Color.yellow;
                break;
            case "WoodenCableDrumCables":
                laserPointer.color = Color.yellow;
                break;            
            case "WoodenCableDrumCollider":
                laserPointer.color = Color.yellow;
                break;
            case "Wooden_Stand":
                laserPointer.color = Color.yellow;
                break;            
            case "BrickStack01":
                laserPointer.color = Color.yellow;
                break;
            case "GarbageDoor_B":
                laserPointer.color = Color.yellow;
                break;            
            case "GarbageDoor_A":
                laserPointer.color = Color.yellow;
                break;
            case "Garbage":
                laserPointer.color = Color.yellow;
                break;            
            case "Bucket":
                laserPointer.color = Color.yellow;
                break;            
            case "RustyShovel":
                laserPointer.color = Color.yellow;
                break;
            case "ConcreteMixer":
                laserPointer.color = Color.yellow;
                break;            
            case "TruckMini":
                laserPointer.color = Color.yellow;
                break;            
            case "Cement":
                laserPointer.color = Color.yellow;
                break;            
            case "Cement_B":
                laserPointer.color = Color.yellow;
                break;            
            case "Scaffolding":
                laserPointer.color = Color.yellow;
                break;            
            case "Container_White":
                laserPointer.color = Color.yellow;
                break;            
            case "Mixer":
                laserPointer.color = Color.yellow;
                break;
        }
    }

    public static void PointerOutside(object sender, PointerEventArgs e)
    {
        //Debug.Log("PointerOutside: " + e.target.name);
        

        switch (e.target.name)
        {
            default:
                laserPointer.color = Color.black;
                break;

        }
    }

    public static void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log("PointerClick: " + e.target.name);
        
        switch (e.target.name)
        {
            case "WoodPlanksBottom":
                laserPointer.color = Color.green;
                break;
            case "WoodPlanksTop":
                laserPointer.color = Color.green;
                break;
            case "WoodPlanksRopes":
                laserPointer.color = Color.green;
                break;
            case "WoodPlanksFabric":
                laserPointer.color = Color.green;
                break;
            case "CementToFall":
                laserPointer.color = Color.green;
                FindObjectOfType<BuilderAnimations>().StartScene(1);
                break;
            case "WoodenCableDrumCables":
                laserPointer.color = Color.green;
                FindObjectOfType<BuilderAnimations>().StartScene(2);
                break;
            case "WoodenCableDrumCollider":
                laserPointer.color = Color.green;
                FindObjectOfType<BuilderAnimations>().StartScene(2);
                break;
            default:
                laserPointer.color = Color.red;
                break;

        }

    }
}
