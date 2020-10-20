using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyFirstWindow : EditorWindow
{
    LevelProfile currentProfile;

    [MenuItem("Window/MyFirstWindow %&#w")]
    public static void Init()
    {
        MyFirstWindow window = EditorWindow.GetWindow(typeof(MyFirstWindow)) as MyFirstWindow;

        window.Show();
    }

    public static void InitWithContent(LevelProfile profile)
    {
        MyFirstWindow window = EditorWindow.GetWindow(typeof(MyFirstWindow)) as MyFirstWindow;

        window.currentProfile = profile;

        window.Show();
        window.position = new Rect(50, 50, 300, 500);
    }

    public void OnGUI()
    {
        if (currentProfile == null) { EditorGUILayout.LabelField("Currently displayed profile is null "); return; }

        if (currentProfile.levelValues.Length > 0)
        {
            float tileWidth = 50f;
            float tileHeight = 50f;
            float tileSpace = 10f;

            //int rowAmount = 2;
            //int columnAmount = 2;

            Event cur = Event.current;

            for (int i = 0; i < currentProfile.levelValues.Length; i++)
            {
                Rect squareRect = new Rect(30 + (tileWidth + tileSpace)* i, 30, tileWidth, tileHeight);
                EditorGUI.DrawRect(squareRect, Color.green);

                if (squareRect.Contains(cur.mousePosition)) EditorGUI.DrawRect(squareRect, Color.blue);
                else EditorGUI.DrawRect(squareRect, Color.green);
            }
            Repaint();
        }
    }
}
