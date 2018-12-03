using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogDisplay : MonoBehaviour {
    public CatalogItem page;

    public Image objectImage;
    public Text desctiption;
    public Text itemNumberText;
	// Use this for initialization
	void Start () {

        objectImage.sprite = page.artwork;
        desctiption.text = page.name;
        itemNumberText.text = page.itemNumber.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
