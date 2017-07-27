using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneHop : MonoBehaviour {

    public float timeInScene = 10f;
    public string nextSceneName; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeInScene -= Time.deltaTime;
        if (timeInScene <= 0)
        {
            SceneManager.LoadScene(nextSceneName);
        }
	}
}
