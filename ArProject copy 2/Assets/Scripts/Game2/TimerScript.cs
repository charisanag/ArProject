using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
    public GameObject timesUPHideCanvas;
	// Use this for initialization
	public void initial () {
       
        timesUPHideCanvas.SetActive(true);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
	}

    void Start()
    {
        
        timesUPHideCanvas.SetActive(true);
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
        //DontDestroyOnLoad(timerBar);
       // DontDestroyOnLoad(timesUPHideCanvas);

    }
	
	// Update is called once per frame
	void Update () {
        

        if (timeLeft > 0)
        {
           
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
            
        }
        else
        {
            timesUPHideCanvas.SetActive(false);
            timeLeft = maxTime;
           

        }
	}
}
