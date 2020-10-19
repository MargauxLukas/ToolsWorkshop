using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(MySecondGameplayScript))]
public class SecondGameplayScriptInspector : Editor
{
    //MySecondGameplayScript mySecondGameplayScript;
    SerializedProperty myColorProperty;
    SerializedProperty redLevel;
    SerializedProperty strings;
    SerializedProperty ennemyProfile;

    public void OnEnable()
    {
        //mySecondGameplayScript = target as MySecondGameplayScript;

        //myColorProperty = serializedObject.FindProperty("color");
        myColorProperty = serializedObject.FindProperty(nameof(MySecondGameplayScript.color)); //même chose qu'ai dessus mais plus modulaire (rename plus facile)
        redLevel = myColorProperty.FindPropertyRelative("r");

        strings = serializedObject.FindProperty(nameof(MySecondGameplayScript.strings));

        ennemyProfile = serializedObject.FindProperty(nameof(MySecondGameplayScript.ennemyProfile));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        if (GUILayout.Button("Turn red"))
        {
            myColorProperty.colorValue = Color.red;
        }

        if (GUILayout.Button("Turn green"))
        {
            myColorProperty.colorValue = Color.green;
        }

        EditorGUILayout.PropertyField(myColorProperty);

        EditorGUILayout.LabelField(redLevel.floatValue.ToString());

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Add one")) strings.arraySize++;
        if (GUILayout.Button("Remove one")) strings.arraySize--;
        EditorGUILayout.EndHorizontal();

        if (strings.arraySize > 0)
        {
            for (int i = 0; i < strings.arraySize; i++)
            {
                EditorGUILayout.PropertyField(strings.GetArrayElementAtIndex(i), new GUIContent("Mon string", "Ceci est un tooltip"));
            }
        }

        EditorGUILayout.PropertyField(ennemyProfile);

        serializedObject.ApplyModifiedProperties();
        //serializedObject.ApplyModifiedPropertiesWithoutUndo(); //Undo déjà présent, utiliser cette funct. si besoin de le suppr.

        //EditorUtility.SetDirty(mySecondGameplayScript);
    }
}
