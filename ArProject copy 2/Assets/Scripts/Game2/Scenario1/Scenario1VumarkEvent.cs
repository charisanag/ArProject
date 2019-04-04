using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Scenario1VumarkEvent : MonoBehaviour
{
    public List<GameObject> modelList;
    public List<string> modelIdList;

    Vuforia.VuMarkManager vuMarkManager;
    SC1Sidepanel sidepanelobject;

    private string targetFound = null;

    public GameObject comfirmObjectCanvas;
    public GameObject winfinishDialog;
    public GameObject sidepanelCanvas;
    public GameObject gameOverDialog;
    public GameObject wrongChoiceDialog;
    public Text triesText;
    int countTries = 3;
    
    private bool stateCanvas = false;
    private int modelN;


    public void Awake()
    {
        SCButtonManager.onClickItem += SCButtonManager_OnClickItem;
    }

    void SCButtonManager_OnClickItem(SCButtonManager obj)
    {
        ObjectFound();
    }


    // Use this for initialization
    void Start () {
        vuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        // Set VuMark detected and lost behavior methods
        vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
        vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);

        //setup sidepanel for interaction
        sidepanelobject = (SC1Sidepanel)FindObjectOfType(typeof(SC1Sidepanel));
        List<Sc1Item> sc1list = sidepanelobject.getSC1List();
        foreach (GameObject item in modelList)
        {
            foreach(Sc1Item it in sc1list)
            {

                if (it.getFound().Equals(false))
                {
                    item.SetActive(false);
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void onVuMarkDetected(VuMarkTarget target)
    {
        targetFound = getVuMarkID(target);
        Debug.Log(targetFound + "  TARGET FOUND");
        for (int i = 0; i < modelIdList.Count; i++)
        {
            if (modelIdList[i].Equals(targetFound) && sidepanelobject.itemIsFounded(targetFound)==false )
            {
                
                comfirmObjectCanvas.SetActive(true);
                //  stateCanvas = true;
                //  showGUI(stateCanvas);
            }
            else if(modelIdList[i].Equals(targetFound) && sidepanelobject.itemIsFounded(targetFound) == true)
            {
                comfirmObjectCanvas.SetActive(false);
                modelList[i].SetActive(true);
           
            }
        }
    }

    private void onVuMarkLost(VuMarkTarget target)
    {
        string targetlost = getVuMarkID(target);
        comfirmObjectCanvas.SetActive(false);
        for (int i = 0; i < modelIdList.Count; i++)
        {
            if (modelIdList[i].Equals(targetlost))
            {
                modelList[i].SetActive(false);
            }
        }
        


    }


    private string getVuMarkID(VuMarkTarget vuMark)
    {
        switch (vuMark.InstanceId.DataType)
        {
            case InstanceIdType.BYTES:
                return vuMark.InstanceId.HexStringValue;
            case InstanceIdType.STRING:
                return vuMark.InstanceId.StringValue;
            case InstanceIdType.NUMERIC:
                return vuMark.InstanceId.NumericValue.ToString();
        }

        return null;
    }

    public void ObjectFound()
    {
        List<Sc1Item> sc1list = sidepanelobject.getSC1List();
        if (targetFound != null)
        {
            Debug.Log(targetFound + "   TargetFound-------");

            Sc1Item itemTofind = sidepanelobject.getItemToBeFound();
   
            bool found = false;
           for (int i=0; i < modelIdList.Count; i++)
            {
                string s2 = modelIdList[i];
                if (s2.Equals(itemTofind.getObjectID()) && itemTofind.getObjectID().Equals(targetFound) )
                {

                    modelList[i].SetActive(true);
                   
                    sidepanelobject.updateItem(itemTofind);
                  
                    comfirmObjectCanvas.SetActive(false);
                     found = true;
                    if (sidepanelobject.win())
                    {
                        winfinishDialog.SetActive(true);
                        sidepanelCanvas.SetActive(false);
                    }
                }   
            }
           if(found == false)
            {
                
                
                if (countTries > 0)
                {
                    wrongChoiceDialog.SetActive(true);
                    countTries--;
                    triesText.text = "Προσπάθειες : " + countTries;
                }
                else
                {
                    triesText.text = "Προσπάθειες : " + 0;
                    sidepanelCanvas.SetActive(false);
                    gameOverDialog.SetActive(true);
                    vuMarkManager.UnregisterVuMarkDetectedCallback(onVuMarkDetected);
                    vuMarkManager.UnregisterVuMarkLostCallback(onVuMarkLost);
                }
            }
        }
    }

    public void showGUI(bool showgui)
    {
        if (showgui == false)
        {
            comfirmObjectCanvas.SetActive(false);
        }
        else
        {
            comfirmObjectCanvas.SetActive(true);
        }
    }
}
