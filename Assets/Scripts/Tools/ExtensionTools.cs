using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionTools {
    public static bool AlmostEquals(this float float1, float float2, float precision = 0.01f) {
        return (Mathf.Abs(float1 - float2) <= precision);
    }

    public static void Shuffle<T>(this IList<T> list) {
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = Random.Range(0, n);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
