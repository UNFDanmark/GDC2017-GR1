using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CooldownTimer : MonoBehaviour {

    public RectTransform rt;
    Vector2 topPosition;
    float cooldownRemaining;
    float totalTime;
    Vector2 newPosition;
    public Image bagrund;
    public Image bar; 


	// Use this for initialization
	void Start ()
    {
        topPosition = rt.anchorMax;
        bagrund.enabled = false;
        bar.enabled = false; 
	}
	
	// Update is called once per frame
	void Update ()
    {

        print(cooldownRemaining);
        if (cooldownRemaining > 0)
        {
            cooldownRemaining -= Time.deltaTime;
            newPosition = new Vector2(topPosition.x * (cooldownRemaining / totalTime), topPosition.y);
            rt.anchorMax = newPosition;

            if(cooldownRemaining <= 0)
            {
                bagrund.enabled = false;
                bar.enabled = false;
            }
        }
	}

    public void StartTimer(float time)
    {
        cooldownRemaining = time;
        totalTime = time;
        bagrund.enabled = true;
        bar.enabled = true;
    }
}
