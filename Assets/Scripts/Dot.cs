using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    private Image dotImage;
    private DotColor currentDotColor = DotColor.UNCOLORED;
    public DotColor CurrentDotColor => currentDotColor;

    private int id;
    public int ID
    {  
        get { return id; } 
        set { id = value; }
    }

    private void Awake()
    {
        dotImage = GetComponent<Image>();
    }

    public void SetDotColor(Color _color) => dotImage.color = _color;

    private void OnMouseDown()
    {
        Debug.Log("CLICKED ON DOT " + id);
        // Go to next DotColor
    }

}

public enum DotColor
{ 
    UNCOLORED,
    COLOR_ONE,
    COLOR_TWO,
    COLOR_THREE
};
