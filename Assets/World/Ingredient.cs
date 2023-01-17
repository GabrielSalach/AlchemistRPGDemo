using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour, IInteractable {
    // Scriptable Object containing all the data 
    [SerializeField] IngredientData ingredientData;
    // Number of ingredients available to harvest from this resource
    [SerializeField] ushort count = 1;

    [SerializeField] Inventory playerInventory;

    GameObject berries;

    void Awake() {
        berries = transform.Find("Berries").gameObject;
        foreach(Transform berry in berries.transform) {
            berry.GetComponent<MeshRenderer>().material.SetColor("_Color", ingredientData.color);
        }
    }

	public void Interact()  {
		if(count > 0) {
            playerInventory.AddItem(ingredientData, count);
            count = 0;
            berries.SetActive(false);
            Debug.Log("Picked up " + ingredientData.itemName);
        } else {
            Debug.Log("Resource is depleted");
        }
	}

	public string GetInteractPrompt()
	{
		return "Harvest " + ingredientData.itemName;
	}
}

