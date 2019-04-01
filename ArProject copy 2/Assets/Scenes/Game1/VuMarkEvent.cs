using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using System;


public class VuMarkEvent : MonoBehaviour
{

	public List<GameObject> modelList;
    public List<string> modelIdList;
   

    private int modelN;
    private Vuforia.VuMarkManager vuMarkManager;
    private string targetFound = null;
    #region PRIVATE_MEMBER_VARIABLES



    #endregion // PRIVATE_MEMBER_VARIABLES

    public delegate void OnUpdatingSideItem();
    public static OnUpdatingSideItem sideItemDelegate;


    public Canvas canvas;
    public GameObject finishedGameDialog;
    public GameObject sidePanelUI;

    private bool stateCanvas = false;
    public event Action ScoChange;
    private FoundObjectScrollList p;

    public void Awake()
    {  
        //Set onclicklistener for buttons in item prefab
        ButtonManager.onClickItem += ButtonManager_onClickItem;
        
    }

   


   


    private void ButtonManager_onClickItem(ButtonManager obj)
    {
        //onClick event get text from item and render object if exists
        SetActiveObject(obj.itemNum.text);
      
    }

    void Start () {
        p = (FoundObjectScrollList)FindObjectOfType(typeof(FoundObjectScrollList));
        // Set VuMarkManager
        vuMarkManager =TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        // Set VuMark detected and lost behavior methods

        vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
        vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);
       // vuMarkManager.RegisterVuMarkBehaviourDetectedCallback();
       
  
        // Deactivate all models 
        foreach (GameObject item in modelList){
			item.SetActive (false);
		}
	}
  

    void Update () {
        	foreach (var vmb in vuMarkManager.GetActiveBehaviours()) {
                    Debug.Log ("ID: "+ getVuMarkID(vmb.VuMarkTarget));
                }
        
        


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
        //canvas.gameObject.SetActive(true);
        /*  targetFound = getVuMarkID(target);
          Debug.Log(targetFound + "  <--------------------------");
          canvas.SetActive(true);
          // Enable canvas objects
           for (int i = 0; i < modelIdList.Count; i++)
           {
               if (modelIdList[i].Equals(targetFound)  )
               {
                 if(p.GetItemState(targetFound) == false)
                   {
                       canvas.SetActive(true);
                   }
                   else
                   {
                       modelList[i].SetActive(true);
                   }

               }
           }*/


        // SetActive(getVuMarkID(target));

    }
    
    private void onVuMarkLost(VuMarkTarget target){
      //  canvas.gameObject.SetActive(false);
        /* canvas.SetActive(false);
        String tartgLost = getVuMarkID(target);
       Debug.Log(tartgLost + "  <++++++++++++++++++++++++++");
        //Debug.Log ("Lost ID: "+ getVuMarkID(target));
        canvas.SetActive(false);
        // Deactivate model by model number
        for (int i = 0; i < modelIdList.Count; i++)
        {
            if (modelIdList[i].Equals(tartgLost)) {
                modelList[i].SetActive(false);
            }
        }
        */
    }
  

    public void SetActiveObject(string selectedItem)
    {
        if (targetFound != null)
        {

            for (int i = 0; i < modelIdList.Count; i++)
            {
                // string s1 = getVuMarkID(targ);
                string s2 = modelIdList[i];

                if (selectedItem.Equals(s2) && selectedItem.Equals(targetFound) && modelList[i].active==false)
                {
                    canvas.gameObject.SetActive(false);
                    modelList[i].SetActive(true);

                    // Set model number
                    modelN = i;
                   
                    //change state of checklist for sidepanel of objects that have been found
                    for (int j = 0; j < ObjectScrollList.cheeckedList.Count; j++){

                        if (ObjectScrollList.cheeckedList[j].itemId.Equals(selectedItem)){
                            ObjectScrollList.cheeckedList[j].setState(true);
                            
                            p.updateItem(selectedItem);
                            if(p.gameover()==true){
                                finishedGameDialog.SetActive(true);
                                sidePanelUI.SetActive(false);
                                ObjectScrollList.cheeckedList = new List<Item>();
                                TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
                            }
                            
                        }
                    }
                        


                }
            }
        }
    }
   
 


    public void showGUI(bool showgui){
        if(showgui==false){
            canvas.gameObject.SetActive(false);
        }
        else{
            canvas.gameObject.SetActive(true);
        }
    }


    
}

