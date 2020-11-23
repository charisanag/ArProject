using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBAnimation : MonoBehaviour,IVirtualButtonEventHandler
{

    public GameObject vbButton;
    public Animator cubeAni;
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        cubeAni.Play("cubeAnimation");
        Debug.Log("Button Pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        cubeAni.Play("none");
        Debug.Log("Button Released");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("mpikeeee");
        vbButton = GameObject.Find("VirtualButton");
       vbButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        cubeAni.GetComponent<Animator>();
     
    }
	void Awake()
    {
        Debug.Log("eeeeeeeee");
    }
    // Update is called once per frame
    void Update () {
		
	}
}
