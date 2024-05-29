using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public TextMesh textTask;
    public TextMesh textScore;
    public TextMesh textMistake;

    public int mistakes = 0;
    public int seenScenesScore = 0;
    public int scene = 0;
    public bool[] seenScenes = new bool[] { false, false, false, false, false, false };

    public static TaskManager instance;

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
        textTask = GameObject.Find("TaskText").GetComponent<TextMesh>();
        textScore = GameObject.Find("ScoreText").GetComponent<TextMesh>();
        textMistake = GameObject.Find("MistakeText").GetComponent<TextMesh>();
    }

    public void SceneComplete()
    {
        seenScenes[scene] = true;
        scene = 0;
        seenScenesScore += 1;
        textScore.text = "Найдено: " + seenScenesScore + " из 5"; 
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

    public void MakeMistake()
    {
        mistakes += 1;
        textMistake.text = "Совершено ошибок: " + mistakes;
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


}



