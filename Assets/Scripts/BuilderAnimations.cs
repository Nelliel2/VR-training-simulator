using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuilderAnimations : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb, rbConcreteTubes;
    private GameObject objBuilder2;
    VisibilityObject obj, cabel, builder2;

    public int scene = 0;
    public bool[] seenScenes = new bool[] {false, false, false, false};

    private float movementSpeed = 2f;

    private Vector3 targetPosition1 = new(-24.8f, 0.1f, 2.9f);
    private Vector3 targetPosition2 = new(-30f, -0.2f, 4.3f);    
    private Vector3 targetPosition3 = new(-35.742f, 0.1f, -1.906f);


    void Start()
    {
        rb = GetComponent<Rigidbody>();


        obj = gameObject.AddComponent<VisibilityObject>();
        obj.setVisibilityObject(GetComponent<Renderer>(), gameObject);
        //obj = new VisibilityObject(GetComponent<Renderer>(), gameObject);
        obj.Hide();

        cabel = GameObject.FindGameObjectWithTag("WoodenCableDrum").AddComponent<VisibilityObject>();
        cabel.setVisibilityObject(cabel.GetComponent<Renderer>(), cabel.gameObject);

        objBuilder2 = GameObject.FindGameObjectWithTag("Builder2");

        builder2 = GameObject.FindGameObjectWithTag("Builder2").AddComponent<VisibilityObject>();
        builder2.setVisibilityObject(builder2.GetComponent<Renderer>(), builder2.gameObject);

        rbConcreteTubes = GameObject.FindGameObjectWithTag("ConcreteTubes").GetComponent<Rigidbody>();

        StartCoroutine(StartingScene(4));

    }

    IEnumerator StartingScene(int num)
    {
        yield return new WaitForSeconds(5f);
        StartScene(num);
    }

    public void StartScene(int number)
    {
        obj.Hide();

        FindObjectOfType<AnimationManager>().Stop("Builder", "Walking");
        FindObjectOfType<AnimationManager>().Stop("Builder", "ClimbingLadder");
        FindObjectOfType<AnimationManager>().Stop("Builder", "Falling");        
        FindObjectOfType<AnimationManager>().Stop("Builder", "FallingUp");
        FindObjectOfType<AnimationManager>().Stop("Builder", "Tripping");

        FindObjectOfType<AnimationManager>().PlayIdle("Builder");
        //if (seenScenes[2])
        //{
        //    cabel.Hide();
        //}
            

        if (!seenScenes[scene])
        { 
            switch (number)
            { 
                case 1:
                    rb.rotation = Quaternion.Euler(0, -90, 0);
                    rb.freezeRotation = true;
                    rb.position = new Vector3(-19, 0.1f, 2.9f);
                    rb.useGravity = true;
                    movementSpeed = 2f;
                    FindObjectOfType<AnimationManager>().Play("Builder", "Walking");
                    FindObjectOfType<AnimationManager>().ChangeUpdateModeAnimatePhysics("Builder");
                    break;

                case 2:
                    rb.rotation = Quaternion.Euler(0, 90, 0);
                    rb.freezeRotation = true;
                    rb.position = new Vector3(-30, 5f, 4.3f);
                    rb.useGravity = false;
                    movementSpeed = 0.5f;
                    FindObjectOfType<AnimationManager>().Play("Builder", "ClimbingLadder");
                    FindObjectOfType<AnimationManager>().ChangeUpdateModeUnscaledTime("Builder");
                    break;

                case 3:
                    rb.rotation = Quaternion.Euler(0, -110, 0);
                    rb.freezeRotation = true;
                    rb.position = new Vector3(-30.5f, 0.1f, 0);
                    rb.useGravity = true;
                    movementSpeed = 2f;
                    FindObjectOfType<AnimationManager>().Play("Builder", "Walking");
                    FindObjectOfType<AnimationManager>().ChangeUpdateModeUnscaledTime("Builder");
                    break;
                case 4:
                    rbConcreteTubes.useGravity = true;
                    StartCoroutine(FailingConcreteTubes(number));
                    return;
                case 5:
                    break;
            }        
            scene = number;
        
            obj.Show();
        }
    }

    IEnumerator FailingConcreteTubes(int number)
    {
        yield return new WaitForSeconds(1.71f);
        scene = number;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((scene == 1) && (!seenScenes[scene]))
        {
            Go(targetPosition1);

            if (transform.position == targetPosition1)
            {


                FindObjectOfType<AnimationManager>().Play("CementToFall", "isPointed");

                FindObjectOfType<AnimationManager>().Play("Builder", "Falling");
                FindObjectOfType<AudioManager>().Play("fallingWithSound");

                seenScenes[scene] = true;
                scene = 0;
                StartCoroutine(DisableCementAnimator());


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
                FindObjectOfType<AudioManager>().Play("screamOfPain");
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
                FindObjectOfType<AudioManager>().Play("fallingWithSound");
                StartCoroutine(FallingOnSand());

            }
        }
        else if ((scene == 4) && (!seenScenes[scene]))
        {
            objBuilder2.transform.localScale = new Vector3(objBuilder2.transform.localScale.x, objBuilder2.transform.localScale.y - 0.1f, objBuilder2.transform.localScale.z);
            objBuilder2.transform.localPosition = new Vector3(objBuilder2.transform.localPosition.x, objBuilder2.transform.localPosition.y - 0.005f, objBuilder2.transform.localPosition.z);

            if (objBuilder2.transform.localScale.y <= 0.1f)
            {
                seenScenes[scene] = true;
                scene = 0;
                
                builder2.Hide();
            }
        }

        IEnumerator FallingOnSand()
        {
            yield return new WaitForSeconds(1.1f);
            FindObjectOfType<AudioManager>().Play("fallingOnSand2");
        }

        IEnumerator DisableCementAnimator()
        {
            yield return new WaitForSeconds(0.6f);
            FindObjectOfType<AnimationManager>().DisableAnimator("CementToFall");
        }
    }

    void Go(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }

}
