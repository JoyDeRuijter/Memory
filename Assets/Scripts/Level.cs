using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level
{
    private int id;
    private LevelData levelData;
    private Dot[] dots;

    private LevelState state = LevelState.WAITING;
    public LevelState State => state;

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

    public void NextState()
    {
        if (state == LevelState.DONE)
            return;
        else
            state++;
    }

    public IEnumerator HandleState()
    {
        Debug.Log("Level " + id + " is currently in state: " + state);
        switch (state)
        {
            case LevelState.WAITING:
                break;
            case LevelState.STARTING:
                NextState();
                break;
            case LevelState.SHOWING:
                //SHOW LOGIC HERE THAT COMES FROM THE LEVELDATAOBJECT
                yield return new WaitForSeconds(2f);
                NextState();
                break;
            case LevelState.PLAYER:
                //WAIT FOR THE CONFIRM BUTTON TO BE PRESSED AND ALLOW THE PLAYER TO CHANGE COLORS
                yield return new WaitForSeconds(2f);
                NextState();
                break;
            case LevelState.RESULTS:
                //RESULTS LOGIC HERE AND WAIT FOR NEXT LEVEL BUTTON TO BE PRESSED
                yield return new WaitForSeconds(2f);
                NextState();
                break;
            case LevelState.DONE:
                yield return new WaitForSeconds(1f);
                GameManager.Instance.LevelManager.NextLevel();
                break;
        }
    }
}

//TODO replace with statepattern
public enum LevelState
{ 
    WAITING,
    STARTING,
    SHOWING,
    PLAYER,
    RESULTS,
    DONE
};