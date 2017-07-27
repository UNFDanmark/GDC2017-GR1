using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

    public float timeSpent;
    public int carrotCount;
    public float carrotBonus = 10;
    public bool runTimer = true;

	// Use this for initialization
	void Start ()
    { 
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;

        if (GameObject.FindObjectsOfType < TimeManager >().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(transform.parent.gameObject);
    }


    private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
    {
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            runTimer = true;
        }
        else
        {
            runTimer = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (runTimer)
        {
            timeSpent += Time.deltaTime;
        }

        GetComponent<Text>().text = "Time: " + (timeSpent - carrotBonus * carrotCount).ToString("F");
	}
    public void giveCarrot()
    {
        carrotCount = carrotCount + 1;
    }
}
