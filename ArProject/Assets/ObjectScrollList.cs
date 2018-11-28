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


    public List<Item> itemlList;
    // den einai aparetito 
    public Transform contentPanel;
    public ObjectScrollList otherObjectList; //se periptwsi pou xriastw allh lista
    public ObjectPool toggleObjectPool;
    
	// Use this for initialization
	void Start () {

        RefreshDisplay();
	}
	
	public void RefreshDisplay()
    {
        AddToggle();
    }
    private void AddToggle()
    {
        for ( int i=0; i < itemlList.Count; i++)
        {
            Item item = itemlList[i];
            GameObject newToggle = toggleObjectPool.GetObject();
            newToggle.transform.SetParent(contentPanel);

            ToggleScript toggleScript = newToggle.GetComponent<ToggleScript>();
            toggleScript.Setup(item, this);
        }
    }
}
