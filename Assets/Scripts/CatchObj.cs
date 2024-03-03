using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchObj : MonoBehaviour
{
    public int CurrentChildren;

    void Start()
    {
        CurrentChildren = transform.childCount;
    }

    void Update()
    {
        if (CurrentChildren < transform.childCount) {
            FindObjectOfType<TaskManager>().AddScore(1);
            Transform child = transform.GetChild(transform.childCount - 1);
            FindObjectOfType<TaskManager>().CheckTaskObj(child.name);
        }
        CurrentChildren = transform.childCount;

    }

}
