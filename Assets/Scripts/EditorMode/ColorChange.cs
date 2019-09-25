using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{

    Button btn;
    ColorManager instance;
    [SerializeField] Image PreviousColor;

    void Start()
    {
        instance = ColorManager.instance;
        btn =GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    void Click()
    {
        instance.NextColor();
        PreviousColor.color = GetComponent<Image>().color;
        GetComponent<Image>().color = instance.GetCurrentColor();
    }
}
