using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Vuforia;

public class ButtonManager : MonoBehaviour
{

    public Text itemNum;
    //for using onclicked button in VumarkEvent 
    public static event Action<ButtonManager> onClickItem = delegate { };


    public void Awake()
    {

    }
    void Start()
    {

        itemNum = GetComponentInParent<Text>();


    }

    public void OnClickedButton()
    {
        onClickItem(this);
    }

}
