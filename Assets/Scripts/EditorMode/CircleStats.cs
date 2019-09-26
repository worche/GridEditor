using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CircleStats : MonoBehaviour
{
    [HideInInspector]
    public Color color = Color.white;
    [HideInInspector]
    public Vector3 pos = Vector3.zero;
    [HideInInspector]
    public Vector3 scale = Vector3.zero;

    //ilerde kullanılması gerekebilir, saklamayı tercih ettim.

    private void Start()
    {
        pos = transform.position;
        scale = transform.localScale;
    }

    private void OnMouseDown()
    {
        color = ColorManager.instance.GetCurrentColor();
        GetComponent<SpriteRenderer>().color = ColorManager.instance.GetCurrentColor();
        
    }
}
