using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VuMarkEvent : MonoBehaviour {

	public List<GameObject> modelList;
    public List<string> modelIdList;

	private int modelN;
	private Vuforia.VuMarkManager vuMarkManager;

    public string id;
    public Canvas canvas;


	void Start () {
		// Set VuMarkManager
		vuMarkManager =TrackerManager.Instance.GetStateManager().GetVuMarkManager();
		// Set VuMark detected and lost behavior methods
		vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
		vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);

		// Deactivate all models 
		foreach(GameObject item in modelList){
			item.SetActive (false);
		}
	}

	void Update () {
        /*		foreach (var vmb in vuMarkManager.GetActiveBehaviours()) {
                    Debug.Log ("ID: "+ getVuMarkID(vmb.VuMarkTarget));
                }
        */
        Debug.Log("OOOOOOOOOOOO");
      
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
        id = PlayerPrefs.GetString("CatalogSelection");
		Debug.Log ("Detected ID: "+ getVuMarkID(target));

        for (int i = 0; i < modelIdList.Count; i++)
        {
            string s1 = getVuMarkID(target);
            string s2 = modelIdList[i];


            if (s1.Equals(s2) )
            {
                if (id.Equals(s2))
                {
                    modelList[i].SetActive(true);

                    // Set model number
                    modelN = i;
                }else{
                    Debug.Log("ELAAAAAAAAAAAAAAAAAAAAAAAAAAA");
                }
            }
        }
        
	}

	public void onVuMarkLost(VuMarkTarget target){
		Debug.Log ("Lost ID: "+ getVuMarkID(target));

		// Deactivate model by model number
		modelList [modelN].SetActive (false);
	}
}
