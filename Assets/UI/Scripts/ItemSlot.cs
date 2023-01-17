using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {

    Image itemSprite;
    TextMeshProUGUI countText;

    void Awake() {
        itemSprite = transform.Find("ItemSprite").GetComponent<Image>();
        countText = transform.Find("Count").GetComponent<TextMeshProUGUI>();
        SetItem(null, 0);
    }

    public void SetItem(ItemData item, ushort count) {
        if(item == null && count == 0) {
            itemSprite.enabled = false;
            countText.enabled = false;
        } else {
            itemSprite.enabled = true;
            countText.enabled = true;
            itemSprite.sprite = item.image;
            countText.SetText(count.ToString());
        }
    }
}