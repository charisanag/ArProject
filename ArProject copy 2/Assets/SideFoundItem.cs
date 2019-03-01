using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideFoundItem : MonoBehaviour {

    public Text itemName;
    public Text foundstate;
    public Image iconImage;


    private Item item;
    private FoundObjectScrollList scrollList;

    public void Setup(Item currentItem, FoundObjectScrollList currentScrollList)
    {
        if (currentItem.state == true)
        {
            item = currentItem;
            itemName.text = item.itemName;
            iconImage.sprite = item.icon;
            //itemId.text = item.itemId;
            scrollList = currentScrollList;
        }
       
    }
}
