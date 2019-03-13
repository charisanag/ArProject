using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoundObjectScrollList : MonoBehaviour {


    public Transform contentPanel;
    public GameObject b; 

    private List<SideFoundItem> selected = new List<SideFoundItem>();



    void Create()
    {

        for (int i = 0; i < ObjectScrollList.cheeckedList.Count; i++)
        {
            Item item = ObjectScrollList.cheeckedList[i];
            GameObject a = (GameObject)Instantiate(b);
            a.transform.SetParent(contentPanel.transform, false);
            SideFoundItem catalog = a.GetComponent<SideFoundItem>();
            catalog.Setup(item, this);
            selected.Add(catalog);

        }

    }


    void Start()
    {

        Create();
    }

    public void updateItem(string itemToUpdate)
    {
        Debug.Log(itemToUpdate);
        for (int j = 0; j < selected.Count; j++){
            Debug.Log(selected[j].GetItem().itemId);
            if (selected[j].GetItem().itemId.Equals(itemToUpdate)){

                selected[j].updateItem();

            }
        }
    }

}
