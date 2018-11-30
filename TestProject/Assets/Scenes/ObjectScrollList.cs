using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public bool state;
}

public class ObjectScrollList : MonoBehaviour {


    public List<Item> itemList;
    // den einai aparetito 
    public Transform contentPanel;
    //public ObjectScrollList otherObjectList; //se periptwsi pou xriastw allh lista
    public ObjectPool toggleObjectPool;

    //xaris
    Toggle m_Toggle;
    public Toggle[] toggles;

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
            
        }
       // GameObject[] btn = GameObject.FindGameObjectsWithTag("toggle");
    }
}
