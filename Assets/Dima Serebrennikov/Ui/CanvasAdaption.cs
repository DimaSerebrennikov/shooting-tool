// CanvasAdaptingMb.csC:\Feeble snow\Assets\Serebrennikov\Ui\CanvasAdaptingMb.csCanvasAdaptingMb.cs
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
namespace Serebrennikov {
    [ExecuteAlways]
    public class CanvasAdaption : MonoBehaviour {
        [SerializeField] float _targetHeightResolution = 1920f;
        [SerializeField] float _targetWidthResolution = 1080f;
        [SerializeField] float _targetDpi = 383f;
        [SerializeField] float _editorScaler;
        [SerializeField] float _koefOfInchPower = 0.5f;
        [SerializeField] CanvasScaler _canvasScaler; /*Reset()*/
        public float TargetHeightResolution { get => _targetHeightResolution; set => _targetHeightResolution = value; }
        public float TargetWidthResolution { get => _targetWidthResolution; set => _targetWidthResolution = value; }
        public float TargetDpi { get => _targetDpi; set => _targetDpi = value; }
        public float EditorScaler { get => _editorScaler; set => _editorScaler = value; }
        public float KoefOfInchPower { get => _koefOfInchPower; set => _koefOfInchPower = value; }
        public CanvasScaler CanvasScaler { get => _canvasScaler; set => _canvasScaler = value; }
        void Reset() {
            _canvasScaler = GetComponent<CanvasScaler>();
        }
        void Update() {
            Obtain_Values(out float widthKoefInch, out float heightKoefInch, out float heightPixelKoef, out float widthPixelKoef);
            float pixelScale;
            float inchScale;
            if (heightPixelKoef < widthPixelKoef) { //Set
                pixelScale = heightPixelKoef;
                inchScale = heightKoefInch;
            } else {
                pixelScale = widthPixelKoef;
                inchScale = widthKoefInch;
            }
            Process_InchScale(ref inchScale);
            float reversedK = 1f - KoefOfInchPower;
            float blendedInchScale = Mathf.Lerp(inchScale, 1f, reversedK);
            CanvasScaler.scaleFactor = pixelScale * blendedInchScale + EditorScaler; //Result
        }
        void Obtain_Values(out float widthKoefInch, out float heightKoefInch, out float heightPixelKoef, out float widthPixelKoef) {
            float curHeight = CurrentHeightInInches(out float curDpi, out float curHeightInch);
            float curWidth = Screen.width;
            float curWidthInch = curWidth / curDpi;
            float targetHeightInch = TargetHeightResolution / TargetDpi;
            float targetWidthInch = TargetWidthResolution / TargetDpi;
            heightKoefInch = curHeightInch / targetHeightInch;
            widthKoefInch = curWidthInch / targetWidthInch;
            heightPixelKoef = curHeight / TargetHeightResolution;
            widthPixelKoef = curWidth / TargetWidthResolution;
        }
        static void Process_InchScale(ref float inchScale) {
            if (inchScale < 1f) { //Inch result
                inchScale = 1f;
            } else {
                inchScale = 1f / inchScale;
            }
        }
        float CurrentHeightInInches(out float curDpi, out float curHeightInch) {
            float curHeight = Screen.height;
            if (Screen.dpi == 0f) {
                curDpi = TargetDpi;
            } else {
                curDpi = Screen.dpi;
            }
            curHeightInch = curHeight / curDpi;
            return curHeight;
        }
    }
}
