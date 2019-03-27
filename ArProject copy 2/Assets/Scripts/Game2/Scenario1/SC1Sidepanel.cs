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
    private GameObject obj = null;

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

    public void setGameObject(GameObject obj)
    {
        this.obj = obj;
    }
    
    
}
public class SC1Sidepanel : MonoBehaviour {



    public Transform contentPanel;
    public GameObject b;
    public List<Sc1Item> sc1itemList;
    private int stepPosition = 0;
    private List<SC1itemOption> selected = new List<SC1itemOption>();

    private List<Sc1Item> tempStepList = new List<Sc1Item>();
    

    void Start()
    {

        foreach(Sc1Item it in sc1itemList) {

            tempStepList.Add(it);
             
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
            selected.Add(itemlist);

        }
       

    }

  

    public List<Sc1Item> getSC1List()
    {
        return sc1itemList;
    }


    //return the position from the array combinig with the step position
    public Sc1Item getItemToBeFound()
    {
        return tempStepList[stepPosition];
    }

    public void updateItem(Sc1Item itemUP)
    {
        foreach(SC1itemOption it in selected)
        {
            if (it.GetSc1Item().getObjectID().Equals(itemUP.objectID)){
                it.updateItem();
                stepPosition++;
            }
        }
    }

    public bool itemIsFounded(string itemid)
    {
        bool fnd = false;
        foreach(Sc1Item it in sc1itemList)
        {
            if (it.getObjectID().Equals(itemid) && it.getFound()==true)
            {
                fnd = true;
            }
        }
        return fnd;
    }

    public bool GameOver()
    {

        return true;
    }

    public bool win()
    {
        bool w = false;
        for (int j = 0; j < selected.Count; j++)
        {
            if (selected[j].GetSc1Item().getFound() == true)
            {

                w = true;

            }
            else
            {
                w = false;
                break;
            }
        }
        return w;
    }
}
