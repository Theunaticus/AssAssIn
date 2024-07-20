using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LevelStuff/LevelDataSO", order = 1)]
public class LevelDataSO : ScriptableObject
{
    public string SceneName;
    public LevelDataSO NextLevel;
    public LevelFlagSO[] RequiredFlags;
}
