using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

    public void Play()
    {
        Application.LoadLevel("TutorialScene");
    }

    public void Play1()
    {
        Application.LoadLevel("TutorialScene1");
    }

    public void Play2()
    {
        Application.LoadLevel("MainScene");
    }

    public void Highscores()
    {
        Application.LoadLevel("HighscoresScene");
    }

    public void MainMenu()
    {
        Application.LoadLevel("MainMenuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
