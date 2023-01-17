using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Effects/EffectData", order = 1)]
public class EffectData : ScriptableObject {
    public string effectName;
    public Sprite effectIcon;

}
