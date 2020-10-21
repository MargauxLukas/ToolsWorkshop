using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SomeCommonComponent))]
public class SomeCommonComponentInspector : Editor
{
    SerializedProperty myProp;
    SerializedProperty forkProp;

    private void OnEnable()
    {
        myProp = serializedObject.GetIterator();
        myProp.NextVisible(true);
        Debug.Log(myProp.name);
        Debug.Log(myProp.displayName);
        Debug.Log(myProp.type);

        while (myProp.NextVisible(true))
        {
            Debug.Log(myProp.name);
            Debug.Log(myProp.displayName);
            Debug.Log(myProp.type);

            if (myProp.type == "Color") forkProp = myProp.Copy();
        }
        myProp.Reset();
    }

    public override void OnInspectorGUI()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        base.OnInspectorGUI();

        sw.Stop();
        EditorGUILayout.LabelField(sw.ElapsedMilliseconds.ToString());
    }
}
