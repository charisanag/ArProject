using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogPbjectScrollList : MonoBehaviour {


    public Transform contentPanel;
    public ObjectPool objectPool;
    // Use this for initialization
    // Use this for initialization
    void Start()
    {
        //done = GetComponent<Button>();
        //done.onClick.AddListener(() => DoneButtonClickListener());
        RefreshDisplay();


    }


    public void RefreshDisplay()
    {
        AddToggle();
    }
    public void AddToggle()
    {
        for (int i = 0; i < ObjectScrollList.cheeckedList.Count; i++)
        {
            Item item = ObjectScrollList.cheeckedList[i];
            GameObject newToggle = objectPool.GetObject();
            newToggle.transform.SetParent(contentPanel);
            CatalogItem toggleScript = newToggle.GetComponent<CatalogItem>();
            toggleScript.Setup(item, this);

            //Setting the toggle Interaction
        }

    }

   
}
