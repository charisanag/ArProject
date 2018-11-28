using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {

    public Toggle toggle;
    public Text nameLabel;
    public Image iconImage;

    private Item item;
    private ObjectScrollList scrollList;
	// Use this for initialization
	void Start () {
		
	}

    public void Setup(Item currentItem, ObjectScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        iconImage.sprite = item.icon;

        scrollList = currentScrollList;
    }
	

}
