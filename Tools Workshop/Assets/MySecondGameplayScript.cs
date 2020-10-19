﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySecondGameplayScript : MonoBehaviour
{
    public Color color;
    [Header("Texts")]
    public string gameString;
    [Multiline]
    public string bigText;

    [Header("Numbers")]
    [Range(0f, 1f)]
    public float slider;

    public Vector2 vector2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
