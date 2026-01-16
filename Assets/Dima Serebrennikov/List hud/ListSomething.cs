using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov {
    public class ListSomething {
        TextMeshProUGUI numberField;
        public ListSomething(string label, TextMeshProUGUI labelField, TextMeshProUGUI numberField) {
            this.numberField = numberField;
            labelField.text = label;
        }
        public void Update<T>(System.Collections.Generic.List<T> items) {
            numberField.text = items.Count.ToString();
        }
    }
}
