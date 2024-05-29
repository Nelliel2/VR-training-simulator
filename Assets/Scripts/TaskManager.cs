using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Valve.Newtonsoft.Json;
using System.IO;

public class TaskManager : MonoBehaviour
{

    public TextMesh textTask;
    public TextMesh textScore;

    public int mistakes = 0;
    public int seenScenesScore = 0;
    public int scene = 0;
    public bool[] seenScenes = new bool[] { false, false, false, false, false, false };


    public void SceneComplete()
    {
        seenScenes[scene] = true;
        scene = 0;
        seenScenesScore += 1;
        textScore.text = "—чет: " + seenScenesScore;
    }    
    
    public bool StartNewScene(int _scene)
    {
        if (seenScenes[_scene] == false && scene == _scene)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MakeMistake()
    {
        mistakes += 1;
    }

    public bool isNotSeenScene()
    {
        if (seenScenes[scene] == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }    
    public bool isNotSeenScene(int _scene)
    {
        if (seenScenes[_scene] == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    void Start()
    {
        textTask = GameObject.Find("TaskText").GetComponent<TextMesh>();
        textScore = GameObject.Find("ScoreText").GetComponent<TextMesh>();
    }
}



