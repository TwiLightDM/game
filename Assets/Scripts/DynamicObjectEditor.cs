// using System.Collections;
// using System.Collections.Generic;
// using UnityEditor;
// using UnityEngine;
//
// [CustomEditor(typeof(DynamicObject))]
// public class DynamicObjectEditor : Editor
// {
//     override public void OnInspectorGUI()
//     {
//         var dynamicObject = target as DynamicObject;
//         dynamicObject.property = (DynamicObject.InteractionProperty)EditorGUILayout.EnumPopup("Property", dynamicObject.property);
//
//         if (dynamicObject.property == DynamicObject.InteractionProperty.AccessInteraction)
//         {
//             EditorGUI.indentLevel++;
//             EditorGUILayout.PrefixLabel("unlockItem");
//             dynamicObject.unlockItem = EditorGUILayout.TextField(dynamicObject.unlockItem);
//             dynamicObject.accessObject= (GameObject)EditorGUILayout.ObjectField("accessObject", dynamicObject.accessObject, typeof(GameObject), true);
//             EditorGUI.indentLevel--;
//         }
//     }
// }
