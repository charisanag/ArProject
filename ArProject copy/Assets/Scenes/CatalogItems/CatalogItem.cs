using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName ="Catalog Item")]

public class CatalogItem : ScriptableObject {

    public Sprite artwork;
    public string itemName;
    public string itemNumber;
	
}
