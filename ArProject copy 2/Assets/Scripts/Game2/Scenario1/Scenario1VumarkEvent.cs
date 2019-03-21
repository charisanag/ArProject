using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Scenario1VumarkEvent : MonoBehaviour, ITrackableEventHandler
{
    public List<GameObject> modelList;
    public List<string> modelIdList;

    Vuforia.VuMarkManager vuMarkManager;

    // Use this for initialization
    void Start () {
        vuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        // Set VuMark detected and lost behavior methods
        vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
        vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   

    private void onVuMarkDetected(VuMarkTarget target)
    {
        
    }

    private void onVuMarkLost(VuMarkTarget target)
    {

    }
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        //throw new System.NotImplementedException();
    }


}
