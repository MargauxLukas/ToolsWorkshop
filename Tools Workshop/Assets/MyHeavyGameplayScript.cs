using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeavyGameplayScript : MonoBehaviour
{
    public Camera gameCamera;
    public Transform selfTransform;
    public Transform cameraTransform;
    public AudioListener audioListener;

    [System.NonSerialized]
    public float speed;

    [SerializeField]
    private float privateProperty;

    public Color color;
    public Vector2 vector2;
    public string gameString;
    public AnimationCurve animCurve;

#if UNITY_EDITOR
    public bool foldoutState;
#endif

    void Update()
    {
        
    }
}