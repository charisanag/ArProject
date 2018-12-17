using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class VuMarkEvent : MonoBehaviour, ITrackableEventHandler
{

	public List<GameObject> modelList;
    public List<string> modelIdList;

	private int modelN;
    //private Vuforia.VuMarkManager vuMarkManager;
    #region PRIVATE_MEMBER_VARIABLES

    private TrackableBehaviour mTrackableBehaviour;

    #endregion // PRIVATE_MEMBER_VARIABLES


    public string id;
    public GameObject canvas;

    private bool stateCanvas = false;


    #region UNTIY_MONOBEHAVIOUR_METHODS
    void Start () {
        // Set VuMarkManager
        //canvas.SetActive(false);
        //showGUI(stateCanvas);
        //vuMarkManager =TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        // Set VuMark detected and lost behavior methods
        //vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
        //vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        // Deactivate all models 
        foreach (GameObject item in modelList){
			item.SetActive (false);
		}
	}
    #endregion // UNTIY_MONOBEHAVIOUR_METHODS

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
    #region PRIVATE_METHODS
    public void onVuMarkDetected(VuMarkTarget target){
        //PlayerPrefs.SetString("VuMarkTarget", getVuMarkID(target));
        //PlayerPrefs.Save();
        //stateCanvas = true;
        //showGUI(stateCanvas);
        //  id = PlayerPrefs.GetString("CatalogSelection");
        //Debug.Log ("Detected ID: "+ getVuMarkID(target));
        Canvas[] canvasComponents = GetComponentsInChildren<Canvas>(true);
        // Enable canvas objects
        foreach (Canvas component in canvasComponents)
        {
            component.enabled = true;
        }


    }

    private void onVuMarkLost(VuMarkTarget target){
        // SceneManager.LoadScene(sceneBuildIndex: 6);
        //Debug.Log ("Lost ID: "+ getVuMarkID(target));
        //stateCanvas = false;
        //showGUI(stateCanvas);
        // Deactivate model by model number
        Canvas[] canvasComponents = GetComponentsInChildren<Canvas>(true);
        foreach (Canvas component in canvasComponents)
        {
            component.enabled = false;
        }
        //modelList [modelN].SetActive (false);
	}
    #endregion // PRIVATE_METHODS

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
    #region PUBLIC_METHODS
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
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
        }
    }
    #endregion // PUBLIC_METHODS

    public void showGUI(bool showgui){
        if(showgui==false){
            canvas.SetActive(false);
        }else{
            canvas.SetActive(true);
        }
    }
}
