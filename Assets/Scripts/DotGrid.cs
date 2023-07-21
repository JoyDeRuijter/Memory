using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotGrid : MonoBehaviour
{
    [SerializeField] private GameObject dotObject;
    [SerializeField] private int amountOfDotRows = 3;
    private int amountOfDots;

    public Dot[] dots;

    private void Awake()
    {
        amountOfDots = amountOfDotRows * amountOfDotRows;
        dots = new Dot[amountOfDots];
        GetComponent<GridLayoutGroup>().constraintCount = amountOfDotRows;

        for (int i = 0; i < amountOfDots; i++)
        {
            dots[i] = Instantiate(dotObject, this.transform).GetComponent<Dot>();
            dots[i].SetID(i);
        }
    }
}
