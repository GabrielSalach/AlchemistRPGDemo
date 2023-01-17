using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Window : MonoBehaviour {

    public string windowTitle;
    TextMeshProUGUI titleText;
    Button closeButton;

    RectTransform rectTransform;
    [SerializeField] RectTransform targetOpen, targetClosed;
    [SerializeField] float transitionTime = 0.3f;
    [SerializeField] AnimationCurve animationCurve;

    void Awake() {
        rectTransform = GetComponent<RectTransform>();

        titleText = transform.Find("TitleBar").Find("TitleTextHolder").Find("TitleText").GetComponent<TextMeshProUGUI>();
        titleText.SetText(windowTitle);

        closeButton = transform.Find("TitleBar").Find("CloseButton").GetComponent<Button>();
        closeButton.onClick.AddListener(CloseWindow);
    }

    public void OpenWindow() {
        rectTransform.anchoredPosition = targetClosed.anchoredPosition;
        LeanTween.move(rectTransform, targetOpen.anchoredPosition, transitionTime).setEase(animationCurve);
    }

    public void CloseWindow() {
        rectTransform.anchoredPosition = targetOpen.anchoredPosition;
        LeanTween.move(rectTransform, targetClosed.anchoredPosition, transitionTime).setEase(animationCurve);
    }

}
