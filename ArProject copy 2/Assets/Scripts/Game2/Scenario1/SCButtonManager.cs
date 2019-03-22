using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SCButtonManager : MonoBehaviour {

    public Text text;
    public static event Action<SCButtonManager> onClickItem = delegate { };

    void Start () {
        text = GetComponentInParent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        onClickItem(this);
    }
}
