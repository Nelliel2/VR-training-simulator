using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator[] animators;
    public static AnimationManager instance;

    void Awake()
    {

        if (instance == null)    // Ёкземпл€р менеджера был найден
        {
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else //if (instance == this)   // Ёкземпл€р объекта уже существует на сцене
        {
            Destroy(gameObject); // ”дал€ем объект
            return;
        }

        DontDestroyOnLoad(gameObject);  // “еперь нам нужно указать, чтобы объект не уничтожалс€ при переходе на другую сцену игры


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisableAnimator(string animator)
    {
        Animator a = Array.Find(animators, anim => anim.name == animator);
        if (a == null)
        {
            Debug.LogWarning("Animator " + name + " not found");
            return;
        }
        a.enabled = false;
    }

    public void EnableAnimator(string animator)
    {
        Animator a = Array.Find(animators, anim => anim.name == animator);
        if (a == null)
        {
            Debug.LogWarning("Animator " + name + " not found");
            return;
        }
        a.enabled = true;
    }


    public void ChangeUpdateModeAnimatePhysics(string animator)
    {
        Animator a = Array.Find(animators, anim => anim.name == animator);

        if (a == null)
        {
            Debug.LogWarning("Animator not found");
            return;
        }

        a.updateMode = UnityEngine.AnimatorUpdateMode.AnimatePhysics;

    }

    public void ChangeUpdateModeUnscaledTime(string animator)
    {
        Animator a = Array.Find(animators, anim => anim.name == animator);

        if (a == null)
        {
            Debug.LogWarning("Animator not found");
            return;
        }

        a.updateMode = UnityEngine.AnimatorUpdateMode.UnscaledTime;

    }

    public void Play(string animator, string name)
    {
        Animator a = Array.Find(animators, anim => anim.name == animator);

        if (a == null)
        {
            Debug.LogWarning("Animator " + animator + " not found" + name);
            return;
        }

        a.SetBool(name: name, value: true);

    }    
    
    public void PlayIdle(string animator)
    {
        Animator a = Array.Find(animators, anim => anim.name == animator);

        if (a == null)
        {
            Debug.LogWarning("Animator not found");
            return;
        }

        a.Play("Idle");

    }

    public void Stop(string animator, string name)
    {
        Animator a = Array.Find(animators, anim => anim.name == animator);

        if (a == null)
        {
            Debug.LogWarning("Animator " + animator + " not found" + name);
            return;
        }

        a.SetBool(name: name, value: false);

    }
}

