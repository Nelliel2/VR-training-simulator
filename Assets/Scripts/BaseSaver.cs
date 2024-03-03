using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class BaseSaver : MonoBehaviour
{
    public Vector3 possition;
    public Quaternion rotation;

    
     [Multiline(15)]
     public string data;


    private void GetInfo()
    {
        possition = transform.position;
        rotation = transform.rotation;
    }
    private void SetInfo()
    {
        transform.position = possition;
        transform.rotation = rotation;
    }

    

    public void Save()
    {
        GetInfo();
        data = JsonUtility.ToJson(this,true);
        File.WriteAllText("D:/Temp/JsonSave"+ gameObject.GetInstanceID()+ ".txt", data);
    }

    public void Load()
    {
        data = File.ReadAllText("D:/Temp/JsonSave" + gameObject.GetInstanceID() + ".txt");
        data = JsonUtility.ToJson(data, this);
        SetInfo();
    }

}
