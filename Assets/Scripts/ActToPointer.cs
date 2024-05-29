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
    static TaskManager taskManager;

    void Start()
    {
        gameObject = GameObject.Find("RightHand");
        taskManager = FindObjectOfType<TaskManager>();
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

    }
  

    public static void PointerInside(object sender, PointerEventArgs e)
    {
        //Debug.Log("PointerInside: " + e.target.name);

        switch (e.target.tag)
        {
            case "isPointed":
                laserPointer.color = Color.yellow;
                break;
            case "WoodenCableDrum":
                if (taskManager.isNotSeenScene(2))
                {
                    laserPointer.color = Color.yellow;
                    laserPointer.clickColor = Color.green;
                }
                break;
            case "Target":
                switch (e.target.name)
                {
                    case "WoodTarget":
                        if (taskManager.isNotSeenScene(3))
                        {
                            laserPointer.color = Color.yellow;
                            laserPointer.clickColor = Color.green;
                        }
                        break;
                    case "CementTarget":
                        if (taskManager.isNotSeenScene(1))
                        {
                            laserPointer.color = Color.yellow;
                            laserPointer.clickColor = Color.green;
                        }
                        break;
                    case "BuilderTarget":
                        if (taskManager.isNotSeenScene(4))
                        {
                            laserPointer.color = Color.yellow;
                            laserPointer.clickColor = Color.green;
                        }
                        break;
                    case "CabelTarget":
                        if (taskManager.isNotSeenScene(5))
                        {
                            laserPointer.color = Color.yellow;
                            laserPointer.clickColor = Color.green;
                        }
                        break;
                }
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
        print("PointerClick: " + e.target.name + e.target.tag);


        switch (e.target.tag)
        {
            case "isPointed":
                taskManager.MakeMistake();
                break;
            case "WoodenCableDrum":
                if (taskManager.isNotSeenScene(2))
                {
                    builderAnimations.StartScene(2);
                }
                break;
            case "Target":
                switch (e.target.name)
                {
                    case "WoodTarget":
                        if (taskManager.isNotSeenScene(3))
                        {
                            builderAnimations.StartScene(3);
                        }
                        break;
                    case "CementTarget":
                        if (taskManager.isNotSeenScene(1))
                        {
                            isCementFall = true;
                            builderAnimations.StartScene(1);
                        }
                        break;   
                    case "BuilderTarget":
                        if (taskManager.isNotSeenScene(4))
                        {
                            builderAnimations.StartScene(4);
                        }
                        break;
                    case "CabelTarget":
                        if (taskManager.isNotSeenScene(5))
                        {
                            builderAnimations.StartScene(5);
                        }
                        break;
                }
                break;
        }

    }
}
