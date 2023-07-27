using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotGrid : MonoBehaviour
{
    [SerializeField] private GameObject dotObject;
    private int noDotRows;
    private int noDots;

    private Dot[] dots;
    public Dot[] Dots => dots;
    private GameObject[] dotObjects;

    public void InitializeGrid(int _noDotRows)
    { 
        noDotRows = _noDotRows;
        noDots = noDotRows * noDotRows;
        dotObjects = new GameObject[noDots];
        dots = new Dot[noDots];
        GetComponent<GridLayoutGroup>().constraintCount = noDotRows;

        for (int i = 0; i < noDots; i++)
        {
            dots[i] = Instantiate(dotObject, this.transform).GetComponent<Dot>();
            dots[i].ID = i;
            dots[i].SetDotColor(GameManager.Instance.LevelManager.CurrentLevel.GetDotColor(dots[i].CurrentDotColor));
            dotObjects[i] = dots[i].gameObject;
        }
    }

    public void UpdateDotColors()
    {
        for (int i = 0; i < noDots; i++)
            dots[i].SetDotColor(GameManager.Instance.LevelManager.CurrentLevel.GetDotColor(dots[i].CurrentDotColor));
    }

    public void DeleteGrid()
    {
        foreach (GameObject dotObject in dotObjects)
            Destroy(dotObject);
    }
}
