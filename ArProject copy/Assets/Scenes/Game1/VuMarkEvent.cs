using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;

public class VuMarkEvent : MonoBehaviour {

	public List<GameObject> modelList;
    public List<string> modelIdList;

	private int modelN;
	private Vuforia.VuMarkManager vuMarkManager;

    public string id;
    public GameObject canvas;


	void Start () {
        // Set VuMarkManager
        canvas.SetActive(false);
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
        PlayerPrefs.SetString("VuMarkTarget", getVuMarkID(target));
        PlayerPrefs.Save();
       // canvas.SetActive(true);

        //  id = PlayerPrefs.GetString("CatalogSelection");
        //Debug.Log ("Detected ID: "+ getVuMarkID(target));



    }

    public void onVuMarkLost(VuMarkTarget target){
        SceneManager.LoadScene(sceneBuildIndex: 6);
        Debug.Log ("Lost ID: "+ getVuMarkID(target));
        canvas.SetActive(false);
        // Deactivate model by model number
        modelList [modelN].SetActive (false);
	}


    public void SetActive(string targ)
    {
        for (int i = 0; i < modelIdList.Count; i++)
        {
           // string s1 = getVuMarkID(targ);
            string s2 = modelIdList[i];


            if (targ.Equals(s2))
            {
         
                modelList[i].SetActive(true);

                // Set model number
                modelN = i;

            }
        }
    }


}
