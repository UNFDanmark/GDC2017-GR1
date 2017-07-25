using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SteadyDeath : MonoBehaviour {

    public Rabbit playerRabbit;

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
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene("DEATH");
    }
}
