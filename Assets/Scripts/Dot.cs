using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dot : MonoBehaviour
{
    private int ID;
    private Image dotImage;
    private Color white = Color.white;
    private Color black = Color.black;
    private Color blue = Color.blue;
    private Color red = Color.red;
    private Color green = Color.green;

    private void Start()
    {
        dotImage = GetComponent<Image>();
        dotImage.color = white;
    }

    private void Update()
    {
        
    }

    public void SetID(int _value) => ID = _value;
}
