using System.Collections.Generic;
using UnityEngine;

public static class TransformExtension {

    public static List<Transform> GetChilds(this Transform transform) {
        List<Transform> childs = new List<Transform>();
        bool firstIgnored = false;
        foreach (Transform child in transform) {
            if (!firstIgnored) {
                firstIgnored = true;
                continue;
            }
            childs.Add(child);
        }
        return childs;
    }
    
}