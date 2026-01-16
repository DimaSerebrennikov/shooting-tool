using System;
using System.Collections.Generic;
using System.IO;
using R3;
using Serebrennikov;
using UnityEngine;
using UnityEngine.UIElements;
class ResizeParameterArea : MonoBehaviour {
    public ReactiveProperty<float> Precentage = new();
    [SerializeField] RectTransform rectTransform;
    [SerializeField] float _default;
    [SerializeField] ShootingToolElement _prefab;
    [SerializeField] Transform _parent;
    float panelHeight;
    IDisposable subscription;
    void Start() {
        panelHeight = rectTransform.rect.height;
        ShootingToolElement element = Instantiate(_prefab);
        RectTransform rect = element.transform as RectTransform;
        rect.SetParent(_parent, false);
        rect.anchoredPosition = Vector2.zero;
        element.Slider.onValueChanged.AddListener(OnSliderChanged);
        element.Name.text = "Resize";
        float savedValue = LoadPrecentage();
        subscription = Precentage.Subscribe(OnPrecentageChanged);
        Precentage.Value = savedValue;
        element.Slider.value = savedValue;
    }
    void OnDestroy() {
        if (subscription != null) {
            subscription.Dispose();
        }
    }
    void OnSliderChanged(float value) {
        Precentage.Value = value;
    }
    void OnPrecentageChanged(float value) {
        SavePrecentage(value);
        float height = Mathf.Lerp(0f, panelHeight, value);
        rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Vertical,
            height
            );
    }
    float LoadPrecentage() {
        return PlayerPrefs.GetFloat(_playerPrefsKey, _default);
    }
    void SavePrecentage(float value) {
        PlayerPrefs.SetFloat(_playerPrefsKey, value);
        PlayerPrefs.Save();
    }
    const string _playerPrefsKey = "ResizeParameterArea.Precentage";
}
