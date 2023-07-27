using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    private int id;
    private LevelData levelData;
    private Dot[] dots;

    public Level(int _id, LevelData _levelData)
    { 
        id = _id;
        levelData = _levelData;
    }

    public Color GetDotColor(DotColor _dotColor)
    {
        switch (_dotColor)
        {
            case DotColor.UNCOLORED:
                return levelData.colors[0];
            case DotColor.COLOR_ONE:
                return levelData.colors[1];
            case DotColor.COLOR_TWO:
                return levelData.colors[2];
            case DotColor.COLOR_THREE:
                return levelData.colors[3];
            default:
                Debug.Log("Level DotColor not found");
                return levelData.colors[0];
        }
    }

    public int GetNoDotRows() => levelData.NoDotRows;

}

