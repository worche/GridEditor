using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleColor : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("click");
        GetComponent<SpriteRenderer>().color = ColorManager.instance.GetCurrentColor();
    }
}
