using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC1Hint : MonoBehaviour {

    public Text countHintText;
    public Text hintText;
    public GameObject Hintdialog;
    private int countHint=3;
    SC1Sidepanel sidepanelobject;
    TimerScript timerScript;
    Button hintButton;

    void Start()
    {
        
        sidepanelobject = (SC1Sidepanel)FindObjectOfType(typeof(SC1Sidepanel));
      //  timerScript =  (new GameObject()).AddComponent<TimerScript>();
        hintButton = GetComponent<Button>();
        countHintText.text = countHint + "";
    }
    public void OnClickHintButton()
    {
       
        
        if (countHint >= 1)
        {
            countHint--;
            Sc1Item item = sidepanelobject.getItemToBeFound();
            countHintText.text = countHint + "";
            
            Hintdialog.SetActive(true);
            hintText.text = item.getHint();
        }
        if(countHint<1)
        {
            hintButton.interactable = false;
        }
        

    }
}
