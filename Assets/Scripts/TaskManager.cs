using UnityEngine;
using System;

public class TaskManager : MonoBehaviour
{
    public TextMesh textTask;
    public TextMesh textScore;
    public TextMesh textTime;
    private Transform canvas;

    //public int mistakes = 0;
    public int seenScenesScore = 0;
    public int scene = 0;
    public bool[] seenScenes = new bool[] { false, false, false, false, false, false};

    public static TaskManager instance;
    private DateTime startTime;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Transform>();
        textTask = GameObject.Find("TaskText").GetComponent<TextMesh>();
        textScore = GameObject.Find("ScoreText").GetComponent<TextMesh>();
        textTime = GameObject.Find("TimeText").GetComponent<TextMesh>();
        startTime = DateTime.Now;
    }

    public void SceneComplete()
    {
        seenScenes[scene] = true;
        scene = 0;
        seenScenesScore += 1;
        textScore.text = "Найдено: " + seenScenesScore + " из 5";
        if (seenScenesScore == 5)
        {
            canvas.position = new Vector3(canvas.position.x, 1.2f, canvas.position.z);
            textTask.color = Color.green;
            textTask.text = "Поздравляем! Все угрозы найдены";
        }
    }    
    
    public bool isStartNewScene(int _scene)
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

    //public void MakeMistake()
    //{
    //    mistakes += 1;
    //    textMistake.text = "Совершено ошибок: " + mistakes;
    //}

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

    private void Update()
    {
        if (seenScenesScore != 5)
        {
            TimeSpan ts = DateTime.Now.Subtract(startTime);
            if (ts.Seconds < 10)
            {
                textTime.text = string.Format("Время: {0}:0{1}", ts.Minutes, ts.Seconds);
            }
            else
            {
                textTime.text = string.Format("Время: {0}:{1}", ts.Minutes, ts.Seconds);
            }
            
        }
        if (Input.GetKeyUp(KeyCode.Q))
            Application.Quit();
    }
}