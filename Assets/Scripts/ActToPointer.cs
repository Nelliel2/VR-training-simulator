using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;



public class ActToPointer : MonoBehaviour
{
    static SteamVR_LaserPointer laserPointer = null;
    static GameObject gameObject;
    SteamVR_Action_Boolean TurnOnLaserPointer;
    public static bool isCementFall = false;
    static BuilderAnimations builderAnimations;

    // Start is called before the first frame update
    void Start()
    {
        // We need to find the laser pointer which we expect attached to our right hand:
        // NOTE: would be better to defend against missing SteamVR_LaserPointer component
        gameObject = GameObject.Find("RightHand");
        builderAnimations = FindObjectOfType<BuilderAnimations>();

        if (gameObject != null)
        {
            laserPointer = GameObject.Find("RightHand").GetComponent<SteamVR_LaserPointer>();

            if (laserPointer != null)
            {
                laserPointer.PointerIn += PointerInside;
                laserPointer.PointerOut += PointerOutside;
                laserPointer.PointerClick += PointerClick;
            }
        }





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
                if (!FindObjectOfType<BuilderAnimations>().seenScenes[3])
                {
                    laserPointer.color = Color.yellow;
                    laserPointer.clickColor = Color.green;
                }
                break;
            case "WoodPlanksTop":
                if (!FindObjectOfType<BuilderAnimations>().seenScenes[3])
                {
                    laserPointer.color = Color.yellow;
                    laserPointer.clickColor = Color.green;
                }
                break;
            case "WoodPlanksRopes":
                if (!FindObjectOfType<BuilderAnimations>().seenScenes[3])
                {
                    laserPointer.color = Color.yellow;
                    laserPointer.clickColor = Color.green;
                }
                break;
            case "WoodPlanksFabric":
                if (!FindObjectOfType<BuilderAnimations>().seenScenes[3])
                {
                    laserPointer.color = Color.yellow;
                    laserPointer.clickColor = Color.green;
                }
                break;
            case "CementTarget":
                if (!FindObjectOfType<BuilderAnimations>().seenScenes[1])
                {
                    laserPointer.color = Color.yellow;
                    laserPointer.clickColor = Color.green;
                }
                break;
            case "WoodenCableDrum":
                if (!FindObjectOfType<BuilderAnimations>().seenScenes[2])
                {
                    laserPointer.color = Color.yellow;
                    laserPointer.clickColor = Color.green;
                }
                break;            
            case "Wooden_Stand":
                laserPointer.color = Color.yellow;
                laserPointer.clickColor = Color.red;
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
            case "Heap_mud (1)":
                laserPointer.color = Color.yellow;
                break;               
            case "Heap_rubble (1)":
                laserPointer.color = Color.yellow;
                break;                   
            case "BrickStack":
                laserPointer.color = Color.yellow;
                break;                
            case "Toilet":
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
                laserPointer.clickColor = Color.red;
                break;

        }
    }

    public static void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log("PointerClick: " + e.target.name + e.target.tag);
        


        switch (e.target.name)
        {
            case "WoodPlanksBottom":
                if (!builderAnimations.seenScenes[3])
                {
                    builderAnimations.StartScene(3);
                }
                break;
            case "WoodPlanksTop":
                if (!builderAnimations.seenScenes[3])
                {
                    builderAnimations.StartScene(3);
                }
                break;
            case "WoodPlanksRopes":
                if (!builderAnimations.seenScenes[3])
                {
                    builderAnimations.StartScene(3);
                }
                break;
            case "WoodPlanksFabric":
                if (!builderAnimations.seenScenes[3])
                {
                    builderAnimations.StartScene(3);
                }
                break;
            case "CementTarget":
                if (!builderAnimations.seenScenes[1])
                {
                    isCementFall = true;
                    builderAnimations.StartScene(1);
                }
                break;            
            case "WoodenCableDrum":
                if (!builderAnimations.seenScenes[2])
                {
                    builderAnimations.StartScene(2);
                }
                break;

        }

    }
}
