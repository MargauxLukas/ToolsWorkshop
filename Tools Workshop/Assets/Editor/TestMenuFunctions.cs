using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestMenuFunctions
{
    [MenuItem("Tools/Leithianîn/Set References %w")]
    public static void HelloWorld()
    {
        Debug.Log("Starting to find references...");

        MyHeavyGameplayScript manager = Object.FindObjectOfType<MyHeavyGameplayScript>();

        Undo.RecordObject(manager, "Just set references");

        manager.audioListener = Object.FindObjectOfType<AudioListener>();
        manager.gameCamera = Object.FindObjectOfType<Camera>();
        manager.selfTransform = manager.transform;
        manager.cameraTransform = manager.gameCamera.transform;
    }
}
