using UnityEditor;
using UnityEngine;

namespace DarkestDimension {

    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label) {
            bool isCorrectType = prop.propertyType == SerializedPropertyType.String;
            string text = isCorrectType ? prop.stringValue : "<non-supported type>";
            EditorGUI.LabelField(position, label.text, text);
        }

    }
}