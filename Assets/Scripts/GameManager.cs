using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("GameManager is NULL");
            return instance;
        }
    }
    #endregion

    [SerializeField] private DotGrid dotGrid;
    public DotGrid DotGrid => dotGrid;
    private LevelManager levelManager;
    public LevelManager LevelManager => levelManager;

    private void Awake()
    {
        instance = this;
        levelManager = this.gameObject.GetComponent<LevelManager>();
    }

}
