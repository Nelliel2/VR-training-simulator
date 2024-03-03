using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInBox : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private string nameMusicUp;
    [SerializeField] private string nameMusicDown;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "item")
        {
            collision.gameObject.transform.SetParent(gameObject.transform, true);
            PlayerAudio(nameMusicUp); 
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "item")
        {
            collision.gameObject.transform.SetParent(gameObject.transform, false);
            PlayerAudio(nameMusicDown); 
        }
    }



    void PlayerAudio(string nameMusic)
    {

        FindObjectOfType<AudioManager>().Play(nameMusic);

    }
}