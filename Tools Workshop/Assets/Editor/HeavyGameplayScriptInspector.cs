using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

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

        EditorGUILayout.LabelField(EditorGUIUtility.labelWidth.ToString());

        int oldIndent = EditorGUI.indentLevel;
        //EditorGUI.indentLevel += 2;
        float oldLabelWidth = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth *= .5f;
        myTargetScript.color = EditorGUILayout.ColorField("My Color", myTargetScript.color);
        EditorGUIUtility.labelWidth = oldLabelWidth;
        EditorGUI.indentLevel = oldIndent;

        string[] options = new string[] { "Option 1", "Option 2", "Option 3" };
        myTargetScript.enumExample = (WrapMode)EditorGUILayout.Popup((int)myTargetScript.enumExample, options);

        EditorGUILayout.HelpBox("Ceci est un texte de Help Box", MessageType.Warning);

        EditorGUI.BeginChangeCheck();

        Transform transformResult = EditorGUILayout.ObjectField("Self Transform", myTargetScript.selfTransform, typeof(Transform), true) as Transform;

        bool userChangedSomething = EditorGUI.EndChangeCheck();

        if (userChangedSomething)
        {
            Debug.Log("Something changed");
            Undo.RecordObject(myTargetScript, "Set object transform");
            myTargetScript.selfTransform = transformResult;
        }

        #region Foldout
        myTargetScript.foldoutState = EditorGUILayout.Foldout(myTargetScript.foldoutState, "Foldout", true);

        if (myTargetScript.foldoutState)
        {
            EditorGUILayout.LabelField("Hello World");
        }
        #endregion

        GUILayout.EndVertical();

        #region Set Refecrences Boutons
        Color baseColor = GUI.color;
        GUI.color = Color.green;

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

        GUI.color = baseColor;
        #endregion

        //EditorSceneManager.MarkAllScenesDirty();
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
