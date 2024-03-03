using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenebleObjects : MonoBehaviour
{
    protected float _openToCloseLerp;

    [SerializeField]
    protected bool _isOpened;

    [SerializeField]
    protected float _openCloseTime = 1f;

    public virtual IEnumerator Open()
    {
       yield return null;

       
    }

    public virtual IEnumerator Close()
    {
        yield return null;

        
    }

    public void OpenOrClose()
    {
        _isOpened = !_isOpened;

        StopAllCoroutines();
        if (_isOpened)
        {
            //FindObjectOfType<AudioManager>().Play("openDoor");
            StartCoroutine(Open());
        }
        else
        {
            //FindObjectOfType<AudioManager>().Play("openDoor");
            StartCoroutine(Close());

        }
    }

    public void PlayAudio (string nameAudio)
    {
        FindObjectOfType<AudioManager>().Play(nameAudio);

    }

}

