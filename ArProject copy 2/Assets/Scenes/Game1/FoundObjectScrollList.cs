using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoundObjectScrollList : MonoBehaviour {


    public Transform contentPanel;
    public GameObject b; 





    void Create()
    {

        for (int i = 0; i < ObjectScrollList.cheeckedList.Count; i++)
        {
            Item item = ObjectScrollList.cheeckedList[i];
            GameObject a = (GameObject)Instantiate(b);
            a.transform.SetParent(contentPanel.transform, false);
            SideFoundItem catalog = a.GetComponent<SideFoundItem>();
            catalog.Setup(item, this);

        }
    }


    void Start()
    {

        Create();
    }

     void Update()
    {
        Create();
    }

}
