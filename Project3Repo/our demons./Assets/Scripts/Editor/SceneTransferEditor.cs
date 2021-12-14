using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// knows what kind of component the custom editor will be for
[CustomEditor(typeof(SceneTransfer))]

public class SceneTransferEditor : Editor
{

    // can get and display properties from object and display it
    SerializedProperty toScene;
    SerializedProperty changeLayer;
    SerializedProperty toLayer;

    // find and fill variables
    private void OnEnable()
    {
        toScene = serializedObject.FindProperty("toScene");
        changeLayer = serializedObject.FindProperty("changeLayer");
        toLayer = serializedObject.FindProperty("toLayer");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // default layout
        EditorGUILayout.PropertyField(toScene);
        EditorGUILayout.PropertyField(changeLayer);

        // if change layer is enabled, conditionally show certain part in editor
        if (changeLayer.boolValue)
        {
            int curentLayer = toLayer.intValue;

            // creating new type of editor GUI, layer field
            toLayer.intValue = EditorGUILayout.LayerField("To Layer",curentLayer);
        }
        

        serializedObject.ApplyModifiedProperties();
    }
}
