using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetSceneAt (level).name == "DEATH" || SceneManager.GetSceneAt(level).name == "Menu")
        {
            Destroy(gameObject);
        }
    }
}
