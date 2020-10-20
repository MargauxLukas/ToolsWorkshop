using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(DebuggingTest))]
public class DebuggingTestInspector : Editor
{
    SerializedProperty oneFirstCamera, oneSecondCamera;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        oneFirstCamera = serializedObject.FindProperty(nameof(DebuggingTest.oneFirstCamera));
        oneSecondCamera = serializedObject.FindProperty(nameof(DebuggingTest.oneSecondCamera));

        serializedObject.ApplyModifiedProperties();
    }
}