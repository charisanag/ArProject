using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogPbjectScrollList : MonoBehaviour {


    public Transform contentPanel;
    public GameObject b;
    private List<CatalogItem> catalogList = new List<CatalogItem>();

    void CreateA()
    {
        for (int i = 0; i < ObjectScrollList.cheeckedList.Count; i++)
        {

            Item item = ObjectScrollList.cheeckedList[i];
            GameObject a = (GameObject)Instantiate(b);
            a.transform.SetParent(contentPanel.transform, false);
            CatalogItem catalog = a.GetComponent<CatalogItem>();
            catalog.Setup(item, this);
            catalogList.Add(catalog);
           
        }
    }
    
    public void UpdateList()
    {
       
            for (int i = 0; i < catalogList.Count; i++)
             {
                if (catalogList[i].GetItem().state == true)
                {
                   Destroy(catalogList[i].gameObject);
                   catalogList.Remove(catalogList[i]);

                }
            }
    }
    void Update()
    {
     
    }
    void Start()
    {
  
        CreateA();
        

    }

 






}
