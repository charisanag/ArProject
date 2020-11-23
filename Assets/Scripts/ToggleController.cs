using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour {
    //in this class we store toggle true values into an array

    bool[] settings;

    public Toggle[] tog;

    void Start()
    {
        settings = new bool[tog.Length];
        for(int i = 0; i <tog.Length; i++)
        {
            settings[i] = true;
            int index = i;

            Toggle t = tog[i];
            t.onValueChanged.AddListener(
                
                (bool check) =>
                {
                    CheckBox(index, check);
                    Debug.Log("Hello", gameObject);
                }
                
                );
        }
    }
    public void CheckBox(int index,bool check)
    {
        settings[index] = check;
       
    }

  
}
