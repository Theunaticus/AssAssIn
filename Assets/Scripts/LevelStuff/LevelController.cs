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
    static Level CurrentLevel;

    public  static  void    SetCurrentLevel (Level  level)
    {
        CurrentLevel = level;
    }

    public  static  void    FinishLevel (Level  level)
    {

    }
}
