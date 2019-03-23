using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Sc1Item
{
    public string todoText;
    private bool found = false;
    public int stepText = 0;
    private Sprite icon;
    public string objectID;

    public void setObjectID(string objectID)
    {
        this.objectID = objectID;
    }
    public string getObjectID() {
        return objectID; 
    }

    public void setFound(bool found)
    {
        this.found = found;
    }
    public bool getFound()
    {
        return found;
    }

    public int getStepText()
    {
        return stepText;
    }
}
public class SC1Sidepanel : MonoBehaviour {



    public Transform contentPanel;
    public GameObject b;
    public List<Sc1Item> sc1itemList;

    private List<int> stepList = new List<int>();
    

    void Start()
    {

        foreach(Sc1Item it in sc1itemList) {

            stepList.Add(it.stepText);
             
        }

        //shuffle list before setup
        for (int j = 0; j < sc1itemList.Count; j++)
        {
            Sc1Item temp = sc1itemList[j];
            int randomIndex = Random.Range(j, sc1itemList.Count);
            sc1itemList[j] = sc1itemList[randomIndex];
            sc1itemList[randomIndex] = temp;
        }
        //setup shuffled list to sidePanel
        for (int i = 0; i < sc1itemList.Count; i++)
        {
            Sc1Item item = sc1itemList[i];
            GameObject a = (GameObject)Instantiate(b);
            a.transform.SetParent(contentPanel.transform, false);
            SC1itemOption itemlist = a.GetComponent<SC1itemOption>();
            itemlist.Setup(item, this);

        }
       

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Sc1Item> getSC1List()
    {
        return sc1itemList;
    }

    public List<int> getStepList()
    {
        return stepList;
    }

    //return the position from the array combinig with the step position
    public int getCurrentPosition()
    {
        int position=-1;
        foreach(Sc1Item it in sc1itemList)
        {
            if (it.getFound() == false)
            {
                
                position = it.stepText-1;
                break;
            }
        }
        return position;
    }
}
