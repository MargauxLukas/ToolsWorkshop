using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Profile", menuName = "Leithianîn/New Level Profile", order = 100)]
public class LevelProfile : ScriptableObject
{
    public float difficulty;
    public Color environmentColor;
    public AnimationCurve curveAnim = AnimationCurve.Linear(0, 0, 1, 1);
    public int[] levelValues;
}
