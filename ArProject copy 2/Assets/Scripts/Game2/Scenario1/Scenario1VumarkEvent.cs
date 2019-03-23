using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Scenario1VumarkEvent : MonoBehaviour, ITrackableEventHandler
{
    public List<GameObject> modelList;
    public List<string> modelIdList;

    Vuforia.VuMarkManager vuMarkManager;
    SC1Sidepanel sidepanelobject;

    private string targetFound = null;

    public GameObject comfirmObjectCanvas;
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
        for (int i = 0; i < modelIdList.Count; i++)
        {
            if (modelIdList[i].Equals(targetFound))
            {

                stateCanvas = true;
                showGUI(stateCanvas);
            }
        }
    }

    private void onVuMarkLost(VuMarkTarget target)
    {
        stateCanvas = false;
        showGUI(stateCanvas);
        // Deactivate model by model number

        modelList[modelN].SetActive(false);
    }
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        //throw new System.NotImplementedException();
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
            Sc1Item itemTofind = sc1list[sidepanelobject.getCurrentPosition()];
           for (int i=0; i < modelIdList.Count; i++)
            {
                string s2 = modelIdList[i];
                if (s2.Equals(itemTofind.getObjectID()) && modelList[i].active == false)
                {
                    //set model number
                    modelN = i;

                    modelList[i].SetActive(true);

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
