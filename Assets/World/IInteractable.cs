using UnityEngine;

public interface IInteractable {
    public abstract string GetInteractPrompt();
    public abstract void Interact();
}
