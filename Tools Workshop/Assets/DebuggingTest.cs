﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggingTest : MonoBehaviour
{
    public LevelProfile level;
    public Camera oneFirstCamera, oneSecondCamera;
    public TextAsset textAsset;

    private void Start()
    {
        //float myFloat = 3;
        //Debug.Log(Square(ref myFloat));
        //Debug.Log(myFloat);

        string fullFileContents = textAsset.text;
        string[] lines = fullFileContents.Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
        List<string>[] fullTable = new List<string>[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            fullTable[i] = new List<string>();
            string[] columns = lines[i].Split(new string[] { "\t" }, StringSplitOptions.None);
            for (int j = 0; j < columns.Length; j++)
            {
                fullTable[i].Add(columns[j]);
            }
        }
    }

    float Square(ref float a)
    {
        a = a * a;
        return a;
    }
}
