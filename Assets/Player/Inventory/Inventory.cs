using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour {
    [SerializeField] Window inventoryWindow;
    RectTransform contentAnchor;

    [SerializeField] List<ItemStack> items;
    Dictionary<ItemData, ushort> itemMap;

    void Awake() {
        itemMap = new Dictionary<ItemData, ushort>();
        contentAnchor = inventoryWindow.transform.Find("Content").GetComponent<RectTransform>();
        foreach(ItemStack stack in items) {
            itemMap.Add(stack.item, stack.count);
        }
    }

    public void AddItem(ItemData item, ushort count) {
        if(itemMap.ContainsKey(item)) {
            itemMap[item] += count;
        } else {
            itemMap.Add(item, count);
        }       
    }

    public void RemoveItem(ItemData item, ushort count) {
        if(itemMap.ContainsKey(item) && itemMap[item] >= count) {
            itemMap[item] -= count;
        }
    }

    public Dictionary<ItemData, ushort> GetItems() {
        return itemMap;
    }

    public void OpenInventory(InputAction.CallbackContext context) {
        // Generates the display
        if(context.performed) {
            Debug.Log("Open");
            int i = 0;
            foreach(KeyValuePair<ItemData, ushort> item in itemMap) {
                if(item.Key != null && item.Value > 0) {
                    contentAnchor.transform.GetChild(i).GetComponent<ItemSlot>().SetItem(item.Key, item.Value);
                    i++;
                }
            }
            inventoryWindow.OpenWindow();
        }
    }


}
