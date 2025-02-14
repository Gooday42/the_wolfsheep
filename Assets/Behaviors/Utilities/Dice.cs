using UnityEngine;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using System;

public class Dice : MonoBehaviour
{
public static bool D100(float value) => UnityEngine.Random.Range(0, 100) < Mathf.Clamp(value, 0f, 100f);
private static bool D(int maxValue, float value) => UnityEngine.Random.Range(0, maxValue) < Mathf.Clamp(value, 0f, maxValue);


}
