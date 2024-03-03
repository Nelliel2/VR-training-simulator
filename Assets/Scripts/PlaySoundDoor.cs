using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundDoor : MonoBehaviour
{
    Vector3 right;
    Vector3 position;
    [SerializeField] private string nameMusic;
    void Start()
    {
        right = transform.right;
        position = transform.position;
    }


    void Update()
    {
        if ((transform.right != right) || (position != transform.position))
        {
            right = transform.right;
            PlayerAudio(nameMusic);
        }


    }
    void PlayerAudio(string nameMusic)
    {

        FindObjectOfType<AudioManager>().Play(nameMusic);

    }
}