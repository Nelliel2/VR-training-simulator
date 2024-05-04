using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSteps : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.LogWarning("Sound not found");
    }


    private void FixedUpdate()
    {
        PlayerStepAudio();
        
    }

    void PlayerStepAudio()
    {
        if ((rb.velocity.x == 0f && rb.velocity.z == 0f))
        {
            Debug.LogWarning("Sound " + "playerSteps" + " not found");


            FindObjectOfType<AudioManager>().Play("playerSteps");

        }
    }
}   