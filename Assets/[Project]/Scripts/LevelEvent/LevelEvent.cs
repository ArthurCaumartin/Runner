using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class LevelEvent
{
    private enum EventType { None, BossTrigger, Accelerate, }
    EventType eventType;
    public string name;
    public float distanceTrigger;
    public float triggerEvery;
    public UnityEvent eventToTrigger;

    [HideInInspector] public bool isAllreadyCall = false;
}


// [CustomPropertyDrawer(typeof(LevelEvent))]
// public class LevelEventPropertyDrawer : PropertyDrawer
// {
//     public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//     {
//         base.OnGUI(position, property, label);
//     }
// }


// [CustomEditor(typeof(LevelEvent)), CanEditMultipleObjects]
// public class LevelEventEditor : Editor
// {
//     public override void OnInspectorGUI()
//     {
//         GUILayout.Label("YAAA");
//         LevelEvent levelEvent = (LevelEvent)target;



//     }   
// }