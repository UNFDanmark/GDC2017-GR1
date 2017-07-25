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


    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        timeOfSprint = -sprintCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        float holdTime = (Time.time - timeOfSprint);
        if (Input.GetKeyDown(speedRun) && holdTime >= sprintCooldown)
        {
            timeOfSprint = Time.time;
        }
        if (Input.GetKeyDown(jumpButton))
        {
            timeOfClick = Time.time;
        }
        //Indsæt en "if-sætning" til at tjekke for kontakt med "jord"
        


    }

    void FixedUpdate()
    {

        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, down, laserR))
        {
            if (Input.GetKeyUp(jumpButton))
            {
                Jump();
            }

        }

        float holdTime = (Time.time - timeOfSprint);
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
        float holdTime = (Time.time - timeOfClick);
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpHeight + Mathf.Min(holdTime, charge) * chargedJump, myRigidbody.velocity.z);
    }

   
    
}
