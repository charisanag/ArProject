using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour {

    public GameObject itemTemplate;

    public GameObject content;

    public void AddButton_Click()
    {
        var copy = Instantiate(itemTemplate);
        copy.transform.parent = content.transform;

    }
}
