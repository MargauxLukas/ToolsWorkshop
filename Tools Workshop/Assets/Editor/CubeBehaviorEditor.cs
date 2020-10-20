﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeBehavior))]
public class CubeBehaviorEditor : Editor
{
    CubeBehavior cubeScript;
    Transform cubeTransform;

    private void OnEnable()
    {
        cubeScript = target as CubeBehavior;
        cubeTransform = cubeScript.transform;
    }

    private void OnDisable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Inspector");
    }

    public void OnSceneGUI()
    {
        Handles.BeginGUI();

        EditorGUILayout.LabelField("Scene");

        

        Handles.EndGUI();

        Vector3 pos = cubeTransform.position;
        Quaternion rot = cubeTransform.rotation;
        float size = 1f;
        Vector3 snap = Vector3.zero;


        /*for (int i = 0; i < cubeScript.outputVector.Length; i++)
        {
            Handles.color = Color.white;
            Handles.DrawLine(pos + cubeScript.outputVector[i], pos + cubeScript.outputVector[(i + 1) % cubeScript.outputVector.Length]);

            Handles.color = i % 2 == 0 ? Color.red : Color.blue;
            cubeScript.outputVector[i] = Handles.FreeMoveHandle(pos + cubeScript.outputVector[i], rot, size * HandleUtility.GetHandleSize(pos + cubeScript.outputVector[i]), snap, Handles.SphereHandleCap) - pos;
        }*/

        cubeScript.radius = Handles.RadiusHandle(rot, pos, cubeScript.radius);

        /*for (int i = 0; i < cubeScript.outputVector.Length; i++)
        {
            Handles.color = i % 2 == 0 ? Color.red : Color.blue;
            cubeScript.outputQuat[i] = Handles.FreeRotateHandle(cubeScript.outputQuat[i], pos + cubeScript.outputVector[i], size * HandleUtility.GetHandleSize(pos + cubeScript.outputVector[i]));
        }*/

        //cubeTransform.position = Handles.FreeMoveHandle(pos, rot, size, snap, Handles.CubeHandleCap);

        EditorUtility.SetDirty(cubeTransform);
        EditorUtility.SetDirty(cubeScript);
    }
}
