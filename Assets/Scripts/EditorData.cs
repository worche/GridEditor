using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EditorData
{
    public IDictionary<int, Vector3> circlePos;
    public IDictionary<int, Color> circleColor;
    public int totalCircle = 0;

    public EditorData()
    {
        circlePos = new Dictionary<int, Vector3>();
        circleColor = new Dictionary<int, Color>();
        
    }
}
