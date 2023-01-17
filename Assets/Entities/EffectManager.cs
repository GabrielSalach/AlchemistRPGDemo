using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {
	[SerializeField] List<Effect> activeEffects;
	List<EffectUI> activeEffectsUI;
	[SerializeField] GameObject effectUIPrefab;
	[SerializeField] Transform buffUIHolder;
	
	void Awake() {
		activeEffects = new List<Effect>();
		activeEffectsUI = new List<EffectUI>();
	}

	public void AddEffect(Effect effect) {
		effect.SetTargetStats(GetComponent<Stats>());		
		activeEffects.Add(effect);
		GameObject instantiated = Instantiate(effectUIPrefab, buffUIHolder.position, Quaternion.identity);
		instantiated.transform.SetParent(buffUIHolder);
		EffectUI instantiatedUI = instantiated.GetComponent<EffectUI>();
		instantiatedUI.SetEffect(effect.EffectData, effect.Duration);
		activeEffectsUI.Add(instantiatedUI);
	}

	void Update() {
		if(activeEffects.Count > 0) {
			for(int i = activeEffects.Count - 1; i >= 0; i--) {
					activeEffects[i].EffectTick(Time.deltaTime);
					activeEffectsUI[i].SetDuration(activeEffects[i].Duration);
					if(activeEffects[i].isEffectActive() == false) {
						activeEffects[i].RemoveEffect();
						activeEffects.Remove(activeEffects[i]);
						Destroy(activeEffectsUI[i].gameObject);
						activeEffectsUI.Remove(activeEffectsUI[i]);
					}
			}
		}
	}
}
