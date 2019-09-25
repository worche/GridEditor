using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EditorData
{
    //Dictionary sistemi için Json formatına çevirebilmek adına harici bir serializable yazılması gerekiyordu. 
    //Hız amacı ile EditorDataBasic ismi ile List'ler ile çalışan versiyonunu yazdım
    
    public IDictionary<int, Vector3> circlePos;
    public IDictionary<int, Color> circleColor;
    public int totalCircle = 0;

    public EditorData()
    {
        circlePos = new Dictionary<int, Vector3>();
        circleColor = new Dictionary<int, Color>();
        
    }
}
