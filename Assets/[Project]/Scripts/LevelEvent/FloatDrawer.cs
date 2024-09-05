



// using UnityEngine;
// using UnityEditor;
// using UnityEngine.UIElements;

// [CustomPropertyDrawer(typeof(float))]
// public class FloatDrawer : PropertyDrawer
// {

//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//     {
//         base.OnGUI(position, property, label);

//         EditorGUI.BeginProperty(position, label, property);
//         position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
//         GUI.backgroundColor = Color.green;
//         EditorGUI.PropertyField(position, property, GUIContent.none);
//         EditorGUI.EndProperty();
//     }
// }