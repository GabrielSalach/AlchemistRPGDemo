using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Linq;

public class WorldInteraction : MonoBehaviour {
    // Reference to the main camera, used to convert world coordinates to screen coordinates
    [SerializeField] Camera mainCamera;
    // Box holding the pickup prompt
    [SerializeField] RectTransform interactUI;
    // Text used in the pickup prompt
    [SerializeField] TextMeshProUGUI interactText;
    // Area in which the pickup prompt needs to be located
    [SerializeField] RectTransform rectangle;

    // Closest interactable to the player
    IInteractable currentInteractable;
    // Current position of that element. Interact prompt appears on top 
    Vector3 currentInteractablePosition;
    // All the Interactables in range
    Dictionary<IInteractable, Transform> interactablesInRange;

    void Awake() {
        interactablesInRange = new Dictionary<IInteractable, Transform>();
    }

    void Update() {
        // if there's at least one ingredient in range, sets the current interactable and position
        if(interactablesInRange.Count > 0) {
            currentInteractable = interactablesInRange.ElementAt(0).Key;
            currentInteractablePosition = interactablesInRange.ElementAt(0).Value.position;
            // If there's more than one, cycles through all of them and updates the current values to the closest one 
            if(interactablesInRange.Count > 1) {
                foreach(KeyValuePair<IInteractable, Transform> entry in interactablesInRange) {
                    if(Vector3.Distance(transform.position, entry.Value.position) < Vector3.Distance(transform.position, currentInteractablePosition)) {
                        currentInteractable = entry.Key;
                        currentInteractablePosition = entry.Value.position;
                    }
                }
            }
            interactText.SetText(currentInteractable.GetInteractPrompt());
        }


        // If the player is in range of an ingredient, updates the position of the pickup prompt
        if(interactUI.gameObject.activeSelf == true) {
            interactUI.transform.position = WorldToScreenSpace(currentInteractablePosition, mainCamera, rectangle);
        }
    }

    // Better way of converting World coordinates to Screen coordinates
    // TODO : Research that shit as well
    public static Vector3 WorldToScreenSpace(Vector3 worldPos, Camera cam, RectTransform area)
    {
        Vector3 screenPoint = cam.WorldToScreenPoint(worldPos);
        screenPoint.z = 0;
    
        Vector2 screenPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(area, screenPoint, cam, out screenPos))
        {
            return screenPos;
        }
    
        return screenPoint;
    }

    // If the player enters the radius of an item to collect
    public void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Interactable")) {
            interactablesInRange.Add(other.GetComponent<IInteractable>(), other.transform);
            ShowPickupUI();
        }
    }

    // Player exiting the radius
    public void OnTriggerExit(Collider other) {
        if(other.CompareTag("Interactable")) {
            interactablesInRange.Remove(other.GetComponent<IInteractable>());
            HidePickupUI();
        }
    }

    // Shows the pickup prompt
    void ShowPickupUI() {
        if(interactablesInRange.Count == 1) {
            interactUI.gameObject.SetActive(true);
        }
    }

    // Hides the pickup prompt
    void HidePickupUI() {
        if(interactablesInRange.Count == 0) {
            interactUI.gameObject.SetActive(false);
        }
    }
    
    public void Interact(InputAction.CallbackContext context) {
        if(context.performed) {
            currentInteractable.Interact();
        }
    }

    // Called when performing the Input assigned to collecting ingredients
/*     public void CollectIngredient(InputAction.CallbackContext context) {
        if(context.performed) {
            if(isInRange) {
                IngredientData pickedIngredient = selectedIngredient.GetIngredient();
                if(pickedIngredient == null) {
                    Debug.Log("Resource is depleted");
                } else {
                    Debug.Log("Picked up " + pickedIngredient.itemName);
                    inventory.AddItem(pickedIngredient, 1);
                }
            }
        }
    } */

}
