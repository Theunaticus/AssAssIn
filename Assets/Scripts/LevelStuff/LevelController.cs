using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController 
{
    static LevelController current;

    public  LevelController ()
    {
        current = this;
    }
    public static Level CurrentLevel { get; private set; }
    

    public  static  void    SetCurrentLevel (Level  level)
    {
        CurrentLevel = level;
    }

    public  static  void    FinishLevel (Level  level)
    {
        if (CurrentLevel.Data.NextLevel!=null)
        {
            SceneManageService.LoadScene(CurrentLevel.Data.NextLevel.SceneName);
        }
    }
}
