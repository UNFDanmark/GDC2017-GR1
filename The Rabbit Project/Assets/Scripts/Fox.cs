using UnityEngine;
using System.Collections;

public class Fox : MonoBehaviour {

    public float Movement = 5;
    public Rigidbody myRigidbody;


    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Move(Movement * Input.GetAxis("Horizontal"));
    }

    public void Move(float speed)
    {
        myRigidbody.velocity = transform.forward * speed + Vector3.up * myRigidbody.velocity.y;

    }
}
