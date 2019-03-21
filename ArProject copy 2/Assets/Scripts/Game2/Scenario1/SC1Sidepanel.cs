using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC2Sidepanel : MonoBehaviour {

    [System.Serializable]
    public class Sc1Item
    {
        public string todoText;
        private bool found = false;
        private string stepText = "0/5";

        public void setFound(bool found)
        {
            this.found = found;
        }
        public bool getFound()
        {
            return found;
        }
    }

    public Transform contentPanel;
    public GameObject b;
    public List<Sc1Item> sc1itemList;

    void Start () {
		
        for(int i=0; i<sc1itemList.Count; i++)
        {
            //Sc1
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
