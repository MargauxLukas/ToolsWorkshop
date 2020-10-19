using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(MyHeavyGameplayScript))]
[CanEditMultipleObjects]
public class HeavyGameplayScriptInspector : Editor
{
    MyHeavyGameplayScript myTargetScript;
    //MyHeavyGameplayScript[] myTargetScripts;

    //bool foldoutState;

    public void OnEnable()
    {
        myTargetScript = target as MyHeavyGameplayScript;

        /*for (int i = 0; i < targets.Length; i++)
        {
            myTargetScripts[i] = targets[i] as MyHeavyGameplayScript;
        }*/

        //Undo.undoRedoPerformed += RecalculateStuffAfterUndo;
    }

    public void RecalculateStuffAfterUndo()
    {

    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        GUILayout.BeginVertical();

        myTargetScript.color = EditorGUILayout.ColorField("My Color", myTargetScript.color);
        myTargetScript.selfTransform = EditorGUILayout.ObjectField("Self Transform", myTargetScript.selfTransform, typeof(Transform), true) as Transform;

        myTargetScript.foldoutState = EditorGUILayout.Foldout(myTargetScript.foldoutState, "Foldout", true);

        if (myTargetScript.foldoutState)
        {
            EditorGUILayout.LabelField("Hello World");
        }

        GUILayout.EndVertical();

        #region Set Refecrences Boutons
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Auto-Set References"))
        {
            AutoSetReferences();
        }

        if (GUILayout.Button("Reset References"))
        {
            SetReferencesToNull();
        }

        GUILayout.EndHorizontal();
        #endregion
    }

    void AutoSetReferences()
    {
        Undo.RecordObject(myTargetScript, "Just set references");

        myTargetScript.audioListener = Object.FindObjectOfType<AudioListener>();
        myTargetScript.gameCamera = Object.FindObjectOfType<Camera>();
        myTargetScript.selfTransform = myTargetScript.transform;
        myTargetScript.cameraTransform = myTargetScript.gameCamera.transform;
    }

    void SetReferencesToNull()
    {
        Undo.RecordObject(myTargetScript, "Just reseted references");

        myTargetScript.audioListener = null;
        myTargetScript.gameCamera = null;
        myTargetScript.selfTransform = null;
        myTargetScript.cameraTransform = null;
    }

    public void OnDisable()
    {
        //Undo.undoRedoPerformed -= RecalculateStuffAfterUndo;
    }
}
