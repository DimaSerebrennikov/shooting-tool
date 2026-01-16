// TulView.csC:\GameDev\Halette\Assets\SereDim\Script\Tool\Tul\TulView.csTulView.cs
using UnityEngine;
using UnityEngine.UIElements;
namespace Serebrennikov.Tb {
    public class StyleSheet {
        public static Button MockButton() {
            Button newButton = new Button();
            newButton.style.paddingRight = 10f;
            newButton.style.paddingLeft = 10f;
            newButton.style.width = 50f;
            newButton.style.height = 50f;
            return newButton;
        }
        public static void SetBorder_AsHigh(VisualElement a) {
            a.style.borderBottomWidth = 1f;
            a.style.borderTopWidth = 1f;
            a.style.borderLeftWidth = 0f;
            a.style.borderRightWidth = 0f;
        }
        public static void SetBorder_AsHigh(VisualElement a, float value) {
            a.style.borderBottomWidth = a.style.borderTopWidth = a.style.borderLeftWidth = a.style.borderRightWidth = value;
        }
        public static void SetMargin(VisualElement a, float value) {
            a.style.marginBottom = a.style.marginTop = a.style.marginLeft = a.style.marginRight = value;
        }
        public static void SetPadding(VisualElement a, float value) {
            a.style.paddingBottom = a.style.paddingTop = a.style.paddingLeft = a.style.paddingRight = value;
        }
        public static void BorderColor(VisualElement a, Color value) {
            a.style.borderBottomColor = a.style.borderTopColor = a.style.borderLeftColor = a.style.borderRightColor = value;
        }
        public static void SetRadius(VisualElement a, float value) {
            a.style.borderTopLeftRadius = a.style.borderTopRightRadius = a.style.borderBottomLeftRadius = a.style.borderBottomRightRadius = value;
        }
        public static void View_HeaderButton(Button view, Texture2D texture, Image image, float sizeImage = 40) {
            float size = 55f;
            StyleSheet.SetBorder_AsHigh(view);
            StyleSheet.BorderColor(view, new Color(0.49f, 0.51f, 0.53f));
            view.style.width = size;
            view.style.height = size;
            view.style.justifyContent = Justify.Center;
            view.style.alignItems = Align.Center;
            view.style.backgroundColor = new Color(0.16f, 0.1f, 0.1f, 0.33f);
            StyleSheet.SetRadius(view, 27);
            /*----*/
            image.image = texture;
            image.tintColor = new Color(0.82f, 0.82f, 0.82f);
            image.style.width = sizeImage;
            image.style.height = sizeImage;
            image.style.alignSelf = StyleKeyword.Auto;
            view.Add(image);
        }
        public static void Get_ViewHeader(VisualElement a) {
            a.style.height = new StyleLength(55f);
            a.style.marginBottom = new StyleLength(26);
            a.style.marginTop = new StyleLength(13);
            a.style.flexDirection = FlexDirection.Row;
            a.style.alignSelf = Align.Center;
        }
    }
}
