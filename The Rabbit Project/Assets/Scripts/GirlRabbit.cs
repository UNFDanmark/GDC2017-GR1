using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GirlRabbit : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("Win Scene");
        }
    }

}
