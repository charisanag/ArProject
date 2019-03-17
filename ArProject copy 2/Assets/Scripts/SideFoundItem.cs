using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SideFoundItem : MonoBehaviour {

    public Text itemName;
    public Text foundstate;
    public Image iconImage;


    private Item item;
    private FoundObjectScrollList scrollList;


    public void Setup(Item currentItem, FoundObjectScrollList currentScrollList)
    {
       
            item = currentItem;
            itemName.text = item.itemName;
            iconImage.sprite = item.icon;
            foundstate.text = "Δεν βρέθηκε";
            //itemId.text = item.itemId;
            scrollList = currentScrollList;
        
       
    }

    public void updateItem()
    {
        item.setState(true);
        foundstate.text = "Βρέθηκε";

    }
    public Item GetItem(){
        return item;
    }
   

}
