using System.Collections;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private bool isUping = false;
    [SerializeField] private string nameMusicUp;
    [SerializeField] private bool isDowning = false;
    [SerializeField] private string nameMusicDown;


    IEnumerator Start()
    {
        AudioListener.volume = 0;
        rb = GetComponent<Rigidbody>();
        yield return new WaitForSeconds(1f);
        AudioListener.volume = 1;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (isDowning)
        {
            if (collision.gameObject.tag != "item")
            { PlayerAudio(nameMusicDown); }
        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (isUping)
        {
            PlayerAudio(nameMusicUp);
        }
        
    }

    void PlayerAudio(string nameMusic)
    {

        FindObjectOfType<AudioManager>().Play(nameMusic);

    }
}
