using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggingTest : MonoBehaviour
{
    public LevelProfile level;
    public Camera oneFirstCamera, oneSecondCamera;

    private void Start()
    {
        float myFloat = 3;
        Debug.Log(Square(ref myFloat));
        Debug.Log(myFloat);
    }

    float Square(ref float a)
    {
        a = a * a;
        return a;
    }
}
