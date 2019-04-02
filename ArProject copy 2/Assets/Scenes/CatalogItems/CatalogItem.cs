using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//In this class rendering prefab item page content from list checklist to canvas
public class CatalogItem : MonoBehaviour
    {
    public Text nameLabel;
    public Image iconImage;
    public Text itemId;
  
   

    private Item item;
    private CatalogPbjectScrollList scrollList;

    public void Setup(Item currentItem , CatalogPbjectScrollList currentScrollList){
        item = currentItem;
        nameLabel.text = item.itemName;
        iconImage.sprite = item.icon;
        itemId.text = item.itemId;
        scrollList = currentScrollList;
    }

    public Item GetItem()
    {
        return item;
    }


}
