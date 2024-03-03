using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCase1 : OpenebleObjects
{ 
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    [SerializeField] private float _moveForwsrdBy= 0.3f;


    void Start()
    {
        _startPosition = transform.position;
        _endPosition = transform.position - transform.forward * _moveForwsrdBy;
    }

   
    public override IEnumerator Open()
    {
        PlayAudio("openCase");
        while (_openToCloseLerp < 1)
        {
            _openToCloseLerp += Time.deltaTime / _openCloseTime;
            transform.position = Vector3.Lerp(_startPosition, _endPosition, _openToCloseLerp);
            
            yield return null;

        }
    }

    public override IEnumerator Close()
    {
        PlayAudio("closeCase");
        while (_openToCloseLerp > 0)
        {
            _openToCloseLerp -= Time.deltaTime / _openCloseTime;
            transform.position = Vector3.Lerp(_startPosition, _endPosition, _openToCloseLerp);
            
            yield return null;

        }
    }




}

