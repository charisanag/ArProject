using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public bool state = false;
    public string itemId;

    public void setState(bool state){
        this.state = state;
    }

}

public class ObjectScrollList : MonoBehaviour {

    
    public List<Item> itemList;
    // den einai aparetito 
    public Transform contentPanel;
    public Button done;

    public ObjectPool toggleObjectPool;

    public static List<Item> cheeckedList= new List<Item>();


  

    // Use this for initialization
    void Start () {
   
        RefreshDisplay();

        
	}

	
	public void RefreshDisplay()
    {
        AddToggle();
    }
    public void AddToggle()
    {    
        for ( int i=0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newToggle = toggleObjectPool.GetObject();
            newToggle.transform.SetParent(contentPanel);
            ToggleScript toggleScript = newToggle.GetComponent<ToggleScript>();
            toggleScript.Setup(item, this);

            //Setting the toggle Interaction
            Toggle toggleButton = newToggle.GetComponent<Toggle>();

            toggleButton.onValueChanged.AddListener(delegate
            {
                if (toggleButton.isOn == true)
                {
                     cheeckedList.Add(item);

                }
                else
                {

                  cheeckedList.Remove(item);
       
                }
            });
        }
       
    }
    
    //Calling this function on Button Done 
    public void DoneButtonClickListener()
    {
        foreach (Item i in cheeckedList)
        {
            Debug.Log("Button clicked = " + i.itemName);
        }
    }

    public List<Item> GetCheckedList()
    {

        List<Item> disctItemList = cheeckedList.Distinct().ToList();
        return disctItemList;
    }
}
