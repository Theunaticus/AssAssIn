using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public LevelDataSO Data;
    LevelFlagCombo[] Flags;

    private void Start()
    {
        Flags = new LevelFlagCombo[Data.RequiredFlags.Length];
        for (int i = 0; i < Flags.Length; i++)
        {
            LevelFlagCombo combo = new LevelFlagCombo();
            combo.Flag = Data.RequiredFlags[i];
            Flags[i] = combo;
        }
        LevelController.SetCurrentLevel(this);
    }

    public  void    SetFlag (LevelFlagSO Flag,bool  State) {
        LevelFlagCombo combo = Flags.Find(f => f.Flag == Flag);
        if (combo!=null)
        {
            combo.Checked = State;
        }
        EvaluateStates();
    }

    void   EvaluateStates ()
    {
        LevelFlagCombo UnfinishedObjective = Flags.Find(f=> !f.Checked);
        if (UnfinishedObjective==null)
        {
            LevelController.FinishLevel(this);
        }
    }
}
