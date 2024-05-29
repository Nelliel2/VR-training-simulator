using System.Collections;
using UnityEngine;

public class BuilderAnimations : MonoBehaviour
{
    private Rigidbody rb, rbConcreteTubes;
    private GameObject objBuilder2;
    private VisibilityObject obj, cabel, builder2;
    private OnCollision builder2Collision;

    static private AnimationManager animationManager;
    static private AudioManager audioManager;
    private TaskManager taskManager;

    private float movementSpeed = 2f;

    private Vector3 targetPosition1 = new(-24.8f, 0.1f, 2.9f);
    private Vector3 targetPosition2 = new(-30f, -0.2f, 4.3f);    
    private Vector3 targetPosition3 = new(-35.742f, 0.1f, -1.906f);
 
    private Vector3 targetPosition51 = new(-17.45f, 0.1f, 22.6f);
    private bool isNotTargetPosition = true;
    private Vector3 targetPosition52 = new(-17.519f, 0.1f, 17.3f);

    void Start()
    {

        animationManager = FindObjectOfType<AnimationManager>();
        audioManager = FindObjectOfType<AudioManager>();
        taskManager = FindObjectOfType<TaskManager>();

        rb = GetComponent<Rigidbody>();

        obj = gameObject.AddComponent<VisibilityObject>();
        obj.setVisibilityObject(GetComponent<Renderer>(), gameObject);
        obj.Hide();

        cabel = GameObject.FindGameObjectWithTag("WoodenCableDrum").AddComponent<VisibilityObject>();
        cabel.setVisibilityObject(cabel.GetComponent<Renderer>(), cabel.gameObject);

        objBuilder2 = GameObject.FindGameObjectWithTag("Builder2");
        

        builder2 = GameObject.FindGameObjectWithTag("Builder2").AddComponent<VisibilityObject>();
        builder2.setVisibilityObject(builder2.GetComponent<Renderer>(), builder2.gameObject);
        builder2Collision = objBuilder2.transform.Find("mixamorig1:Hips").GetComponent<OnCollision>();

        rbConcreteTubes = GameObject.FindGameObjectWithTag("ConcreteTubes").GetComponent<Rigidbody>();
   
        //StartCoroutine(StartingScene(5));


    }

    IEnumerator StartingScene(int num)
    {
        yield return new WaitForSeconds(5f);
        StartScene(num);
    }

    public void StartScene(int number)
    {
        obj.Hide();

        animationManager.Stop("Builder", "Walking");
        animationManager.Stop("Builder", "ClimbingLadder");
        animationManager.Stop("Builder", "Falling");        
        animationManager.Stop("Builder", "FallingUp");
        animationManager.Stop("Builder", "Tripping");
        animationManager.Stop("Builder", "BeingElectrocuted");

        animationManager.PlayIdle("Builder");
        

        if (taskManager.isNotSeenScene())
        { 
            switch (number)
            { 
                case 1:
                    rb.rotation = Quaternion.Euler(0, -90, 0);
                    rb.freezeRotation = true;
                    rb.position = new Vector3(-19, 0.1f, 2.9f);
                    rb.useGravity = true;
                    movementSpeed = 2f;
                    animationManager.Play("Builder", "Walking");
                    animationManager.ChangeUpdateModeAnimatePhysics("Builder");
                    break;

                case 2:
                    rb.rotation = Quaternion.Euler(0, 90, 0);
                    rb.freezeRotation = true;
                    rb.position = new Vector3(-30, 5f, 4.3f);
                    rb.useGravity = false;
                    movementSpeed = 0.5f;
                    animationManager.Play("Builder", "ClimbingLadder");
                    animationManager.ChangeUpdateModeUnscaledTime("Builder");
                    break;

                case 3:
                    rb.rotation = Quaternion.Euler(0, -110, 0);
                    rb.freezeRotation = true;
                    rb.position = new Vector3(-30.5f, 0.1f, 0);
                    rb.useGravity = true;
                    movementSpeed = 2f;
                    animationManager.Play("Builder", "Walking");
                    animationManager.ChangeUpdateModeUnscaledTime("Builder");
                    break;
                case 4:
                    audioManager.Play("breakingRope");
                    animationManager.Play("Rope", "Falling");
                    rbConcreteTubes.useGravity = true;
                    taskManager.scene = number;
                    return;
                case 5:
                    rb.rotation = Quaternion.Euler(0, 90, 0);
                    rb.freezeRotation = true;
                    rb.position = new Vector3(-21.22f, 0.1f, 22.6f);
                    rb.useGravity = true;
                    movementSpeed = 2f;
                    animationManager.Play("Builder", "Walking");
                    animationManager.ChangeUpdateModeUnscaledTime("Builder");
                    break;
            }
            taskManager.scene = number;

        
            obj.Show();
        }
    }

    void FixedUpdate()
    {
        if (taskManager.isStartNewScene(1))
        {
            Go(targetPosition1);

            if (transform.position == targetPosition1)
            {
                animationManager.Play("CementToFall", "isPointed");

                animationManager.Play("Builder", "Falling");
                audioManager.Play("fallingWithSound");

                taskManager.SceneComplete();
                StartCoroutine(DisableCementAnimator());
            }

        }
        else if (taskManager.isStartNewScene(2))
        {
            Go(targetPosition2);

            if (transform.position == targetPosition2)
            {

                rb.freezeRotation = false;
                animationManager.Play("Builder", "FallingUp");
                audioManager.Play("screamOfPain");
                rb.useGravity = true;
                taskManager.SceneComplete();

            }
        }
        else if (taskManager.isStartNewScene(3))
        {
            Go(targetPosition3);

            if (transform.position == targetPosition3)
            {

                animationManager.Play("Builder", "Tripping");
                taskManager.SceneComplete();
                audioManager.Play("fallingWithSound");
                StartCoroutine(FallingOnSand());

            }
        }
        else if (taskManager.isStartNewScene(4))
        {

            if (builder2Collision.isCollisioning)
            {
                audioManager.Play("fallingHeavyObject");
                animationManager.Play("Builder2", "Falling");
                audioManager.Play("screamOfPain2");
                objBuilder2.transform.localPosition = new Vector3(objBuilder2.transform.localPosition.x, objBuilder2.transform.localPosition.y - 0.1f, objBuilder2.transform.localPosition.z);
                taskManager.SceneComplete();
            }
        }
        else if (taskManager.isStartNewScene(5))
        {
            if (isNotTargetPosition)
            {
                Go(targetPosition51);

                if (transform.position == targetPosition51)
                {

                    isNotTargetPosition = false;
                }

            }
            else
            {
                if (transform.rotation != Quaternion.Euler(0, 180, 0))
                {
                    transform.Rotate(0, 10, 0);
                }
                Go(targetPosition52);

                if (transform.position == targetPosition52)
                {
                    animationManager.Play("Builder", "BeingElectrocuted");
                    taskManager.SceneComplete();
                    StartCoroutine(FallingOnSand(5.8f));
                    StartCoroutine(FallingOnSand(4f));               
                }

            }


        }

        IEnumerator FallingOnSand(float sec = 1.1f)
        {
            yield return new WaitForSeconds(sec);
            audioManager.Play("fallingOnSand2");
        }

        IEnumerator DisableCementAnimator()
        {
            yield return new WaitForSeconds(0.6f);
            animationManager.DisableAnimator("CementToFall");
        }
    }

    void Go(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

    }

}
