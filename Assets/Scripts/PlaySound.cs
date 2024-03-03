using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private string nameMusicUp;
    [SerializeField] private string nameMusicDown;


    IEnumerator Start()
    {
        AudioListener.volume = 0;
        rb = GetComponent<Rigidbody>();
        yield return new WaitForSeconds(4f);
        AudioListener.volume = 1;
    }



        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "item")
        { PlayerAudio(nameMusicDown); }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    
        PlayerAudio(nameMusicUp); 
        
    }

    void PlayerAudio(string nameMusic)
    {

        FindObjectOfType<AudioManager>().Play(nameMusic);

    }
}
