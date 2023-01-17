using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Items/ItemData", order = 1)]
public class ItemData : ScriptableObject {
    // Unique ID
    public ushort itemID;
    // Name of the item
    public string itemName;
    // Sprite of the item
    public Sprite image;
}
