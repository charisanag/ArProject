using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(fileName ="New Item", menuName ="Catalog Item")]

//public class CatalogItem : ScriptableObject {
public class CatalogItem : MonoBehaviour
    {
        public Text nameLabel;
    public Image iconImage;
    public string itemId;
   

    private Item item;
    private CatalogPbjectScrollList scrollList;

    public void Setup(Item currentItem , CatalogPbjectScrollList currentScrollList){
        item = currentItem;
        nameLabel.text = item.itemName;
        iconImage.sprite = item.icon;
        itemId = item.itemId;
        scrollList = currentScrollList;
    }

}
