using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
namespace Serebrennikov {
    public class ListBehaviour : MonoBehaviour {
        [SerializeField] string _label = "Items";
        [SerializeField] Image _background;
        [SerializeField] TextMeshProUGUI _labelField;
        [SerializeField] TextMeshProUGUI _numberField;
        ListSomething _tracker;
        void Awake() {
            _tracker = new ListSomething(_label, _labelField, _numberField);
        }
        void Reset() {
            CreateBackground();
            CreateLabel();
            CreateNumber();
        }
        public void SetLabelText(string label) {
            _labelField.text = label;
        }
        public void UpdateList<T>(System.Collections.Generic.List<T> list) {
            _tracker.Update(list);
        }
        void CreateBackground() {
            if (_background == null) {
                GameObject bg = GetOrCreateUnder("Background", transform);
                _background = EnsureComponent<Image>(bg);
                _background.color = Color.black;
                RectTransform rt = bg.GetComponent<RectTransform>();
                rt.anchorMin = Vector2.zero;
                rt.anchorMax = Vector2.one;
                rt.offsetMin = Vector2.zero;
                rt.offsetMax = Vector2.zero;
            }
        }
        void CreateNumber() {
            if (_numberField == null) {
                GameObject no = GetOrCreateUnder("Number", transform);
                _numberField = EnsureComponent<TextMeshProUGUI>(no);
                _numberField.enableAutoSizing = true;
                _numberField.text = "Number";
                _numberField.fontSize = 24f;
                _numberField.alignment = TextAlignmentOptions.Center;
                AdjustNumberPosition(_numberField.rectTransform);
            }
        }
        void CreateLabel() {
            if (_labelField == null) {
                GameObject labelGo = GetOrCreateUnder("Label", transform);
                _labelField = EnsureComponent<TextMeshProUGUI>(labelGo);
                _labelField.enableAutoSizing = true;
                _labelField.fontSize = 24f;
                _labelField.text = _label;
                _labelField.horizontalAlignment = HorizontalAlignmentOptions.Center;
                AdjustLabelPosition(_labelField.rectTransform);
            }
        }
        void AdjustLabelPosition(RectTransform rt) {
            rt.anchorMin = new Vector2(0f, 0.75f);
            rt.anchorMax = new Vector2(1f, 1.0f);
            rt.pivot = new Vector2(0.5f, 1.0f);
            rt.anchoredPosition = Vector2.zero;
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }
        void AdjustNumberPosition(RectTransform rt) {
            rt.anchorMin = new Vector2(0f, 0.25f);
            rt.anchorMax = new Vector2(1f, 0.75f);
            rt.pivot = new Vector2(0.5f, 0.5f);
            rt.anchoredPosition = Vector2.zero;
            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }
        GameObject GetOrCreateUnder(string name, Transform parent) {
            Transform foundTransform = parent.Find(name);
            if (foundTransform != null) return foundTransform.gameObject;
            GameObject go = new GameObject(name);
            go.transform.SetParent(parent);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            return go;
        }
        T EnsureComponent<T>(GameObject go) where T : Component {
            T c = go.GetComponent<T>();
            if (c == null) c = go.AddComponent<T>();
            return c;
        }
    }
}
