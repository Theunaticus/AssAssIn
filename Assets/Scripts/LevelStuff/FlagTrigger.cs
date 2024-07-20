using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTrigger : MonoBehaviour
{
    [SerializeField] LevelFlagSO MyFlag;

    public  void    GetFlag ()
    {
        LevelController.CurrentLevel.SetFlag(MyFlag, true);
    }
}
