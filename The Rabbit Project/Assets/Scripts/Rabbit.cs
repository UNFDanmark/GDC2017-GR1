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
    public float spinTime = 1;
    public LayerMask groundLayer;
    public bool isWalking = false;
    public bool isStanding = true;


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
            isWalking = false;
            isStanding = false;
            rabbit.CrossFade("Rul 0", spinTime);
            timeOfSprint = Time.time;
        }
        if (Input.GetKeyDown(jumpButton))
        {
            timeOfClick = Time.time;
        }
        


    }

    void FixedUpdate()
    {
        float holdTime = (Time.time - timeOfSprint);

        if (Physics.Raycast(transform.position + Vector3.up * 0.2f, Vector3.down, laserR, groundLayer))
        {
            if (Input.GetKeyUp(jumpButton))
            {
                Jump();

            }
            else if (holdTime >= timeOfBoost)
            {
                if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.001f)
                {

                    if (!isStanding)
                    {
                        
                        isStanding = true;
                        isWalking = false;
                        rabbit.CrossFade("Idle 0", spinTime);
                    }
                }
                else
                {

                    if (!isWalking)
                    {
                        isWalking = true;
                        isStanding = false;
                        rabbit.CrossFade("Gå 0", spinTime);
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
        myRigidbody.velocity = transform.forward * speed + Vector3.up * myRigidbody.velocity.y;

    }
    public void Jump()
    {
        isWalking = false;
        isStanding = false; 
        float holdTime = (Time.time - timeOfClick);
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpHeight + Mathf.Min(holdTime, charge) * chargedJump, myRigidbody.velocity.z);
        rabbit.CrossFade("Hop", spinTime);
    }

   
    
}
