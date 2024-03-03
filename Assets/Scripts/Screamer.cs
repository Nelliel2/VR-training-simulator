using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;



public class Screamer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] VideoPlayer _video;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            new WaitForSeconds(2);
            _video.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerManager>() != null)
        {
            _video.Stop();
        }
    }

}
