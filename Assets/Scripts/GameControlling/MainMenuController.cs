using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public  void    PlayGame ()
    {
        SceneManageService.LoadScene(SceneManageService.Level1SceneName);
    }

    public  void    ExitGame()
    {
        Application.Quit();
    }
}
