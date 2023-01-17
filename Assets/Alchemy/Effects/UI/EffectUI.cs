using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectUI : MonoBehaviour {

    Image timerWheel;
    float baseTime;

    void Awake() {
        timerWheel = transform.Find("Meter").GetComponent<Image>();
    }

    public void SetEffect(EffectData data, float baseTime) {
        transform.Find("EffectIcon").GetComponent<Image>().sprite = data.effectIcon;
        this.baseTime = baseTime;
    }

    public void SetDuration(float remainingTime) {
        timerWheel.fillAmount = remainingTime/baseTime;
    }
}
