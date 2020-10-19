using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnnemyProfile
{
    public Color color;
    public float speed;
    public Vector3 spawnPos;
    public AnimationCurve acceleration;
}

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

    public string[] strings;

    public EnnemyProfile ennemyProfile;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
