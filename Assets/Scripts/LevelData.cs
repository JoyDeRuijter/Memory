using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDataObject", menuName = "LevelDataObjects/LevelDataObject")]
public class LevelData : ScriptableObject
{
    public int id;
    public int NoDotRows;
    [SerializeField] public Color[] colors = new Color[4];
}
