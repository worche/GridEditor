using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager instance;
    Queue<Color> colorQueue;

    Color defaultColor;
    [ColorUsageAttribute(true, false)] [SerializeField] Color color1=Color.white;
    [ColorUsageAttribute(true, false)] [SerializeField] Color color2=Color.white;
    [ColorUsageAttribute(true, false)] [SerializeField] Color color3=Color.white;

    Color selecterColor;
    #region Singeleton
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        colorQueue = new Queue<Color>();
        defaultColor = Color.white;
        selecterColor = defaultColor;
        colorQueue.Enqueue(color1);
        colorQueue.Enqueue(color2);
        colorQueue.Enqueue(color3);
    }

    public Color GetCurrentColor()
    {
        if (selecterColor == null)
            return defaultColor;

        return selecterColor;
    }
    public void NextColor()
    {
        selecterColor = colorQueue.Dequeue();
        colorQueue.Enqueue(selecterColor);
    }
}
