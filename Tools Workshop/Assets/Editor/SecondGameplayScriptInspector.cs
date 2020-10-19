using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MySecondGameplayScript))]
public class SecondGameplayScriptInspector : Editor
{
    //MySecondGameplayScript mySecondGameplayScript;

    public void OnEnable()
    {
        //mySecondGameplayScript = target as MySecondGameplayScript;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        serializedObject.ApplyModifiedProperties();

        //EditorUtility.SetDirty(mySecondGameplayScript);
    }
}
