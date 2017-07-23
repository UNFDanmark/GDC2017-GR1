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
    public float chargedJump = 7.5f;
    public float timeOfClick = 0;
    public float speedRunFast = 8;
    public KeyCode speedRun = KeyCode.LeftShift;
    public float speedTime = 1;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpButton))
        {
            timeOfClick= Time.time;
        }
   //Indsæt en "if-sætning" til at tjekke for kontakt med "jord"


        if (Input.GetKeyUp(jumpButton))
        {
            Jump();
        }

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(speedRun))
        {
   //speedTime, så shift ikke vare evigt men kun et sekund 
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
