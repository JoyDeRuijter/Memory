using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    private Image dotImage;
    private DotColor currentDotColor = DotColor.UNCOLORED;
    public DotColor CurrentDotColor => currentDotColor;

    public event Action OnDotClicked;

    private int id;
    public int ID
    {  
        get { return id; } 
        set { id = value; }
    }

    private void Awake()
    {
        dotImage = GetComponent<Image>();
        OnDotClicked += transform.parent.GetComponent<DotGrid>().UpdateDotColors;
    }

    public void SetDotColor(Color _color) => dotImage.color = _color;

    public void NextColor()
    {
        if (currentDotColor == DotColor.COLOR_THREE)
            currentDotColor = DotColor.UNCOLORED;
        else
            currentDotColor++;

        //TODO change this into an observer pattern
        OnDotClicked?.Invoke();
    }
}

public enum DotColor
{ 
    UNCOLORED,
    COLOR_ONE,
    COLOR_TWO,
    COLOR_THREE
};
