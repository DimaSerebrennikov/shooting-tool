// ScreenDebugText.csC:\Feeble snow\Assets\Serebrennikov\Feeble snow components\ScreenDebugText.csScreenDebugText.cs
using UnityEngine;
using UnityEngine.UI;
namespace Serebrennikov {
    public static class ScreenDebugText {
        // Writes a centered debug message on screen.
        public static void Show(string message) {
            GameObject canvasObject = new("DebugCanvas");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            GameObject textObject = new("DebugText");
            textObject.transform.SetParent(canvasObject.transform, false);
            TextMeshProUGUI text = textObject.AddComponent<TextMeshProUGUI>();
            text.text = message;
            text.fontSize = 36f;
            text.alignment = TextAlignmentOptions.Center;
            text.color = Color.white;
            RectTransform rectTransform = text.rectTransform;
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.sizeDelta = new Vector2(900f, 200f);
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
