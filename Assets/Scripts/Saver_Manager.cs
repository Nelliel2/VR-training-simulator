using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Saver_Manager : MonoBehaviour
{
    public UnityEvent save;
    public UnityEvent load;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            save.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            load.Invoke();
        }
    }
}
