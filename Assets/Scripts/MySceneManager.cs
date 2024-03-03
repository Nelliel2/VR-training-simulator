using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MySceneManager : MonoBehaviour
{
    public static MySceneManager instance;



    void Awake()
    {
        if (instance == null)    // Ёкземпл€р менеджера был найден
        {
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance != this)   // Ёкземпл€р объекта уже существует на сцене
        {
            Destroy(gameObject); // ”дал€ем объект
            instance = this;  // «адаем ссылку на экземпл€р объекта
        }

        DontDestroyOnLoad(gameObject);  // “еперь нам нужно указать, чтобы объект не уничтожалс€ при переходе на другую сцену игры
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
            OnExit();
    }


    public void LoadNewScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OpenURL()
    {
        Application.OpenURL("https://drive.google.com/drive/u/1/folders/1xwqxNDKn-W3pQvok6tTXHJgwPU4aWjgz");
    }

}