using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EditorDataBasic 
{
    public List< Vector3> circlePos;
    public List< Color> circleColor;
    public List<int> circleId;
    public int totalCircle;

    public EditorDataBasic()
    {
        circleId = new List<int>();
        circlePos = new List< Vector3>();
        circleColor = new List< Color>();
        totalCircle = 0;

    }
}
