using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuilderAnimations : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    VisibilityObject obj;

    public int scene = 0;
    private bool[] seenScenes = new bool[] {false, false, false, false};

    private float movementSpeed = 2f;

    private Vector3 targetPosition1 = new Vector3(-24.8f, 0.1f, 2.9f);
    private Vector3 targetPosition2 = new Vector3(-30f, -0.2f, 4.3f);    
    private Vector3 targetPosition3 = new Vector3(-36f, 0.1f, -2f);


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        obj = new VisibilityObject(GetComponent<Renderer>(), gameObject);
        obj.Hide();

        StartScene(3);
    }



    public void StartScene(int number)
    {
        obj.Hide();
        

        switch (number)
        { 
            case 1:
                rb.rotation = Quaternion.Euler(0, -90, 0);
                rb.freezeRotation = true;
                rb.position = new Vector3(-19, 0.1f, 2.9f);
                rb.useGravity = true;
                movementSpeed = 2f;
                FindObjectOfType<AnimationManager>().Play("Builder", "Walking");
                break;

            case 2:
                rb.rotation = Quaternion.Euler(0, 90, 0);
                rb.freezeRotation = true;
                rb.position = new Vector3(-30, 5f, 4.3f);
                rb.useGravity = false;
                movementSpeed = 0.5f;
                FindObjectOfType<AnimationManager>().Play("Builder", "ClimbingLadder");
                break;

            case 3:
                rb.rotation = Quaternion.Euler(0, -110, 0);
                rb.freezeRotation = true;
                rb.position = new Vector3(-30.5f, 0.1f, 0);
                rb.useGravity = true;
                movementSpeed = 2f;
                FindObjectOfType<AnimationManager>().Play("Builder", "Walking");
                break;
        }        
        scene = number;
        
        obj.Show();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if ((scene == 1) && (!seenScenes[scene]))
        {
            Go(targetPosition1);

            if (transform.position == targetPosition1)
            {
                
                FindObjectOfType<AnimationManager>().Play("Builder", "Falling");
                
                FindObjectOfType<AnimationManager>().Play("CementToFall", "isPointed");

                seenScenes[scene] = true;
                scene = 0;

                //FindObjectOfType<AnimationManager>().disableAnimator("CementToFall");
            }
            
        }
        else if ((scene == 2) && (!seenScenes[scene]))
        {
            Go(targetPosition2);
            
            if (transform.position == targetPosition2)
            {

                rb.freezeRotation = false;
                FindObjectOfType<AnimationManager>().Play("Builder", "FallingUp");
                
                rb.useGravity = true;
                seenScenes[scene] = true;
                scene = 0;
     
            }
        }
        else if ((scene == 3) && (!seenScenes[scene]))
        {
            Go(targetPosition3);
    
            if (transform.position == targetPosition3)
            {
               
                FindObjectOfType<AnimationManager>().Play("Builder", "Tripping");     
                seenScenes[scene] = true;
                scene = 0;
     
            }
        }
    }

    void Go(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

}
