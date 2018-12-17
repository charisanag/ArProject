using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using System;

public class VuMarkEvent : MonoBehaviour,ITrackableEventHandler
{

	public List<GameObject> modelList;
    public List<string> modelIdList;

	private int modelN;
    private Vuforia.VuMarkManager vuMarkManager;
    #region PRIVATE_MEMBER_VARIABLES

    

    #endregion // PRIVATE_MEMBER_VARIABLES



    public GameObject canvas;

    private bool stateCanvas = false;

    public void Awake()
    {  
        //Set onclicklistener for buttons in item prefab
        ButtonManager.onClickItem += ButtonManager_onClickItem;
    }

    private void ButtonManager_onClickItem(ButtonManager obj)
    {
        //onClick event get text from item and render object if exists
        SetActive(obj.itemNum.text);
        canvas.SetActive(false);
    }

    void Start () {
        // Set VuMarkManager
        vuMarkManager =TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        // Set VuMark detected and lost behavior methods
        vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
        vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);
       
  
        // Deactivate all models 
        foreach (GameObject item in modelList){
			item.SetActive (false);
		}
	}
  

    void Update () {
        /*		foreach (var vmb in vuMarkManager.GetActiveBehaviours()) {
                    Debug.Log ("ID: "+ getVuMarkID(vmb.VuMarkTarget));
                }
        */
        


    }

	private string getVuMarkID(VuMarkTarget vuMark){
		switch (vuMark.InstanceId.DataType){
		case InstanceIdType.BYTES:
			return vuMark.InstanceId.HexStringValue;
		case InstanceIdType.STRING:
			return vuMark.InstanceId.StringValue;
		case InstanceIdType.NUMERIC:
			return vuMark.InstanceId.NumericValue.ToString();
		}

		return null;
	}

    public void onVuMarkDetected(VuMarkTarget target){

        // Enable canvas objects
         stateCanvas = true;
        showGUI(stateCanvas);
        
       // SetActive(getVuMarkID(target));

    }

    private void onVuMarkLost(VuMarkTarget target){
    
        //Debug.Log ("Lost ID: "+ getVuMarkID(target));
        //stateCanvas = false;
        //showGUI(stateCanvas);
        // Deactivate model by model number
  
        //modelList [modelN].SetActive (false);
	}
  

    public void SetActive(string target)
    {
        for (int i = 0; i < modelIdList.Count; i++)
        {
           // string s1 = getVuMarkID(targ);
            string s2 = modelIdList[i];


            if (target.Equals(s2))
            {
         
                modelList[i].SetActive(true);
                // Set model number
                modelN = i;

            }
        }
    }
   
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
       /* Debug.Log("KSANAVRETHIKEEEE");
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            stateCanvas = true;
            showGUI(stateCanvas);
        }
        else
        {
            stateCanvas = false;
            showGUI(stateCanvas);
        }*/
    }


    public void showGUI(bool showgui){
        if(showgui==false){
            canvas.SetActive(false);
        }else{
            canvas.SetActive(true);
        }
    }


  
}
