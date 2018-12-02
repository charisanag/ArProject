using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
public class StartGame1 : MonoBehaviour {

    Button myButton;
    // Use this for initialization
    void Start()
    {
        myButton = GetComponent<Button>();

        if ((ObjectScrollList.cheeckedList != null) && (!ObjectScrollList.cheeckedList.Any()))
            {
            myButton.interactable = false;
        }
        else
        {
            myButton.interactable = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void gameStart()
    {
        SceneManager.LoadScene(3);
        foreach (Item i in ObjectScrollList.cheeckedList)
        {
            Debug.Log("Button clicked = " + i.itemName);
        }

    }
}
