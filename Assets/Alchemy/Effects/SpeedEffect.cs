using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : Effect
{
    bool effectApplied;
    float speedMultiplier = 2;

    public SpeedEffect(float duration, EffectData data) {
        this.effectData = data;
        this.baseDuration = duration;
        effectApplied = false;
    }


	public override void EffectTick(float deltaTime) {
        if(effectApplied == false) {
            targetStats.Speed *= speedMultiplier;
            effectApplied = true;
        }
        this.baseDuration -= deltaTime;
	}

	public override bool isEffectActive() {
        return this.baseDuration >= 0;
	}

	public override void RemoveEffect() {
		targetStats.Speed /= speedMultiplier;
	}

	public override void SetTargetStats(Stats targetStats) {
        this.targetStats = targetStats;
	}
}
