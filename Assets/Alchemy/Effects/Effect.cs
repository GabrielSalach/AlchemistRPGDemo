using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect {
    protected float baseDuration;
    protected Stats targetStats;
    protected EffectData effectData;
    
    public float Duration {get {return baseDuration;}}
    public EffectData EffectData {get {return effectData;}}

    public abstract void SetTargetStats(Stats targetStats);
    public abstract bool isEffectActive();
    public abstract void EffectTick(float deltaTime);
    public abstract void RemoveEffect();
}
