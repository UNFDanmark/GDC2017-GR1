using UnityEngine;
using System.Collections;

public class CarrotScript : MonoBehaviour {

    public float rotationSpeed = 20;
    public float xRotation = 0.25f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotationSpeed * Time.deltaTime * xRotation, rotationSpeed * Time.deltaTime, 0, Space.World);
    }
    //        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
}
