using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC1itemOption : MonoBehaviour {

    public Text todoText;
    public Image stateImage;
    public Text stepText;
    public Sprite imgCorrect;
    public Sprite imgDefault;

    private Sc1Item item;
    private SC1Sidepanel sc1sidepanelScrolllist;

    public void Setup(Sc1Item currentItem, SC1Sidepanel currentSidepanelScrolllist)
    {
        item = currentItem;
        todoText.text = item.todoText;
       // stepText.text = item.stepText+"/4";
        stateImage.sprite = imgDefault;
        sc1sidepanelScrolllist = currentSidepanelScrolllist;
    }

    public void updateItem()
    {
        stepText.text = item.stepText + "/4";
        stateImage.sprite = imgCorrect;
    }

    public Sc1Item GetSc1Item()
    {
        return item;
    }
}
