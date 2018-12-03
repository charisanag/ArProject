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

    void Update () {
		
	}

    public void gameStart()
    {
        SceneManager.LoadScene(7);
        foreach (Item i in ObjectScrollList.cheeckedList)
        {
            Debug.Log("Button clicked = " + i.itemName);
        }

    }
}
