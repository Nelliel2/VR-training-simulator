using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Newtonsoft.Json;
using System.IO;

public class TaskManager : MonoBehaviour
{

    public TMP_Text textTask;
    public TMP_Text textScore;
    public int score = 0;

    List<Task> tasks;
    int numberTask;

    void Start()
    {
        textTask = GameObject.Find("TaskText").GetComponent<TMP_Text>();
        textScore = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        LoadJsonTasks();
        ChangeTask();
    }

    public void LoadJsonTasks()
    {
        using (StreamReader r = new StreamReader("Tasks.json"))
        {
            string json = r.ReadToEnd();
            //tasks = JsonConvert.DeserializeObject<List<Task>>(json);
        }

    }

    public void AddScore(int countScore)
    {
        score += countScore;
        textScore.text = "Счет: " + score;
    }

    public void CheckTaskObj(string objName)
    {
        string[] objNameWords = objName.Split(' ');
        if (objName == tasks[numberTask].objectName)
        {
            ChangeTask(++numberTask);
        }
        else if (objNameWords[0] == tasks[numberTask].objectName)
        {
            ChangeTask(++numberTask);
        }

    }

    IEnumerator waiterColor()
    {
        FindObjectOfType<AudioManager>().Play("Complete");
        //green
        ChangeColor("#0CAB0D");

        yield return new WaitForSeconds(2f);

        //grey
        ChangeColor("#ABAAAA");

        textTask.text = "Задание: " + tasks[numberTask].taskText;

    }
    void ChangeColor(string hex)
    {
        Color newColor;
        if (ColorUtility.TryParseHtmlString(hex, out newColor))
        {
            textTask.color = newColor;
        }
    }

    public void ChangeTask(int numberTask = 0)
    {

        if (numberTask < tasks.Count)
        {
            if (numberTask > 0) StartCoroutine(waiterColor());
            else if (numberTask == 0) textTask.text = "Задание: " + tasks[numberTask].taskText;
        }
    }
}


public class Task
{
    public string taskText;
    public string objectName;
}
