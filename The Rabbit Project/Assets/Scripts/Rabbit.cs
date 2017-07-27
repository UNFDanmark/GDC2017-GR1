using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    public float Movement = 7.5f;
    public Rigidbody myRigidbody;
    public float jumpHeight = 10;
    public KeyCode jumpButton = KeyCode.Space;
    public float charge = 2;
    public float chargedJump = 5;
    public float timeOfClick = 0;
    public float speedRunFast = 8;
    public KeyCode speedRun = KeyCode.LeftShift;
    public float speedTime = 0;
    public float timeOfSprint = 0;
    public float timeOfBoost = 0;
    public float sprintCooldown = 0;
    public float laserR = 0.6f;
    public Animator rabbit;
    public GameObject modelOfRabbit;
    public float spinTime = 1;
    public LayerMask groundLayer;
    public TimeManager timeManager;


    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        timeOfSprint = -sprintCooldown;
        rabbit = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float holdTime = (Time.time - timeOfSprint);
        if (Input.GetKeyDown(speedRun) && holdTime >= sprintCooldown)
        {
            rabbit.CrossFade("Rul 0", spinTime);
            timeOfSprint = Time.time;
        }
        if (Input.GetKeyDown(jumpButton))
        {
            if (Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.down, laserR, groundLayer))
            {
                Jump();
                timeOfClick = Time.time;
            }
        }
        


    }

    void FixedUpdate()
    {
        float holdTime = (Time.time - timeOfSprint);
        float jumpTime = (Time.time - timeOfClick);

        if (Input.GetKey(jumpButton))
        {
            if (jumpTime <= charge)
            {
                myRigidbody.AddForce(0, chargedJump, 0);
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.down, laserR, groundLayer))
        {

        
            if (holdTime >= timeOfBoost)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.001f)
                {

                    if (!rabbit.GetCurrentAnimatorStateInfo(0).IsName("Idle 0"))
                    {
                        rabbit.Play("Idle 0");
                    }
                }
                else
                {

                    if (!rabbit.GetCurrentAnimatorStateInfo(0).IsName("Gå 0"))
                    {
                        rabbit.Play("Gå 0");
                    }
                }
            }
        }
        

        if (holdTime < timeOfBoost)
        {
            Move(Movement * Input.GetAxis("Horizontal") * speedRunFast);
        }
        else
        {
            Move(Movement * Input.GetAxis("Horizontal"));

        }

    }

    public void Move(float speed)
    {
        myRigidbody.velocity = Vector3.forward * speed + Vector3.up * myRigidbody.velocity.y;
        if (speed > 0)
        {
            modelOfRabbit.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (speed < 0)
        {
            modelOfRabbit.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    public void Jump()
    {
        
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpHeight, myRigidbody.velocity.z);
        rabbit.CrossFade("Hop", spinTime);
    }

    void OnTriggerEnter(Collider trigger)
    {
        PickUp(trigger.gameObject.GetComponent<CarrotScript>());
    }

    public void PickUp(CarrotScript coin)
    {
        Destroy(coin.gameObject);
        timeManager.giveCarrot();
    }

}
