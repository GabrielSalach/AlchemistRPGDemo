using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPotion : MonoBehaviour, IInteractable {
	public EffectManager effectManager;	
	[SerializeField] EffectData effectData;


	public string GetInteractPrompt() {
		return "Drink potion";
	}

	public void Interact() {
		effectManager.AddEffect(EffectFactory.GetEffect(effectData));
		Material potMaterial = GetComponent<MeshRenderer>().material;
		potMaterial.SetTextureScale("_MainTex", new Vector2(1,0));
	}
}
