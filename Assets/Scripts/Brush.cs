using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Brush : MonoBehaviour
{
    [Header("Pen Properties")]
    public Transform tip;
    public Material drawingMaterial;
    public Material tipMaterial;
    [Range(0.01f, 0.1f)]
    public float penWidth = 0.01f;
    public Color[] penColors;

    [Header("Hands & Grabbable")]
    public SteamVR_Action_Single rightHand;

    private LineRenderer currentDrawing;
    private int index;
    private int currentColorIndex;

    private void Start()
    {
        currentColorIndex = 0;
    }

    private void Update()
    {

        if (SteamVR_Input.GetState("GrabGrip", SteamVR_Input_Sources.RightHand) || SteamVR_Input.GetState("GrabGrip", SteamVR_Input_Sources.LeftHand))
        {
            Debug.LogWarning("Sound not found");
            Draw();
        }
        else if (currentDrawing != null)
        {
            currentDrawing = null;
        }
    }

    private void Draw()
    {
        if (currentDrawing == null)
        {
            index = 0;
            currentDrawing = new GameObject().AddComponent<LineRenderer>();
            currentDrawing.material = drawingMaterial;
            currentDrawing.startColor = currentDrawing.endColor = penColors[currentColorIndex];
            currentDrawing.startWidth = currentDrawing.endWidth = penWidth;
            currentDrawing.positionCount = 1;
            currentDrawing.SetPosition(0, tip.position);
        }
        else
        {
            var currentPos = currentDrawing.GetPosition(index);
            if (Vector3.Distance(currentPos, tip.position) > 0.01f)
            {
                index++;
                currentDrawing.positionCount = index + 1;
                currentDrawing.SetPosition(index, tip.position);
            }
        }
    }

}

