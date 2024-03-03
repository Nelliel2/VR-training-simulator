using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineDraw;
    public Rigidbody brush;

    void Start()
    {
        lineDraw.startWidth = 0.2f;
        lineDraw.endWidth = 0.2f;
        lineDraw.positionCount = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "linen")
        {
            Vector3 currentPoint = GetWorldCoordinate(brush.position);
            lineDraw.positionCount++;
            lineDraw.SetPosition(lineDraw.positionCount - 1, currentPoint);
        }
    }

    private Vector3 GetWorldCoordinate(Vector3 brushPosition)
    {
        Vector3 brushPoint = new Vector3(brushPosition.x, 0, brushPosition.z);
        return brushPoint;
    }
}

