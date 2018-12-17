using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public Text itemNum;
    public Canvas canvas;
    //string id;
	void Start () {

        itemNum = GetComponentInParent<Text>();

	}
	

	public void OnClickedButton () {

        // PlayerPrefs.SetString("CatalogSelection", itemNum.text);
        // PlayerPrefs.Save();
       // id = PlayerPrefs.GetString("VuMarkTarget");
        //VuMarkEvent vu = new VuMarkEvent();
       // vu.SetActive(id);
      //   Debug.Log("You select the item " + PlayerPrefs.GetString("CatalogSelection"));
        // canvas.GetComponent<Canvas>().enabled = false;
       // SceneManager.LoadScene(sceneBuildIndex: 6);
       
    }
}
