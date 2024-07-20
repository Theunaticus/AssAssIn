using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManageService 
{
    public static string Level1SceneName => "SampleScene";

    public  static  void    LoadScene(string    SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
