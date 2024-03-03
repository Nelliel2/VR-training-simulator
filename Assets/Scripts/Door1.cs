using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : OpenebleObjects
{
    private Vector3 _startRotation;
    private Vector3 _targetRotation;
    [SerializeField] private float _rotateByDegrees = -90f;

   
    void Start()
    {
        _startRotation = transform.rotation.eulerAngles;
        _targetRotation = transform.rotation.eulerAngles + Vector3.up * _rotateByDegrees;
        
    }

    public override IEnumerator Open()
    {
        if (_rotateByDegrees != 0)
        {
            if (gameObject.name.Contains("Case")) PlayAudio("openCase");
            else PlayAudio("openDoor");
            
            while (_openToCloseLerp < 1)
            {
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(_startRotation), Quaternion.Euler(_targetRotation), _openToCloseLerp);
                _openToCloseLerp += Time.deltaTime / _openCloseTime;
                yield return null;

            }
        }
        else PlayAudio("closed");
    }

    public override IEnumerator Close()
    {
        if (_rotateByDegrees != 0)
        {
            if (gameObject.name.Contains("Case")) PlayAudio("closeCase");
            else PlayAudio("closeDoor");
            while (_openToCloseLerp > 0)
            {
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(_startRotation), Quaternion.Euler(_targetRotation), _openToCloseLerp);
                _openToCloseLerp -= Time.deltaTime / _openCloseTime;
                yield return null;

            }
        }
        else PlayAudio("closed");
    }
}
