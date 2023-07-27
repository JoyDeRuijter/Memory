using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Level[] levels;
    public Level[] Levels => levels;

    [SerializeField] private LevelData[] levelDataObjects;
    private Level currentLevel;
    public Level CurrentLevel => currentLevel;
    private int currentLevelIndex;

    private void Start()
    {
        for (int i = 0; i < levelDataObjects.Length; i++)
        { 
            levels = new Level[levelDataObjects.Length];
            levels[i] = new Level(i, levelDataObjects[i]);
        }

        Debug.Log("Levels: " + levels);
        currentLevel = levels[0];
        currentLevelIndex = 0;
        Debug.Log("CurrentLevel: " + currentLevel);
        GameManager.Instance.DotGrid.InitializeGrid(currentLevel.GetNoDotRows());

        currentLevel.NextState();
    }

    private void Update()
    {
        StartCoroutine(currentLevel.HandleState());
    }

    public void NextLevel()
    {
        if (currentLevelIndex + 1 > levels.Length - 1)
        {
            //GAME OVER
        }
        else
        {
            currentLevelIndex++;
            Debug.Log("CurrentLevelIndex: " + currentLevelIndex);
            currentLevel = levels[currentLevelIndex];
            GameManager.Instance.DotGrid.DeleteGrid();
            GameManager.Instance.DotGrid.InitializeGrid(currentLevel.GetNoDotRows());

            currentLevel.NextState();
        }
    }
}
