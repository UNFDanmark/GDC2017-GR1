using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Fox : MonoBehaviour
{
    public float Movement = 5;
    public Rigidbody myRigidbody;
    public Rabbit playerRabbit;
    public float foxWalk = 10;
    public bool foxTurnR = true;
    public Vector3 firstTurn;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }


    // Use this for initialization
    void Start () {
        firstTurn = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Move(Movement);
    }

    public void Move(float speed)
    {
        float walkDistance = (firstTurn - transform.position).magnitude;
        if (walkDistance >= foxWalk)
        {
            if (foxTurnR)
            {
                TurnLeft();
            }
            else
            {
                TurnRight();
            }
        } 
        myRigidbody.velocity = transform.forward * speed + Vector3.up * myRigidbody.velocity.y;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene("DEATH");
    }

    public void TurnLeft()
    {
        firstTurn = transform.position;
        foxTurnR = false;
        transform.Rotate(0, 180, 0);
    }
     public void TurnRight()
    {
        firstTurn = transform.position;
        foxTurnR = true;
        transform.Rotate(0, 180, 0);
    }
}
