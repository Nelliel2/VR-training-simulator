using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
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


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        Play("background");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }

        if (! s.source.isPlaying) 
        {
            s.source.Play();
        } 
        
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found");
            return;
        }


        s.source.Play();
    }
}
