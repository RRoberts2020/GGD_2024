using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSystem : MonoBehaviour
{
    public void MainScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void Game1Scene(string ComedyZone)
    {
        SceneManager.LoadScene(ComedyZone);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            KillSwitch();
        }
    }

    private void KillSwitch()
    {
        Application.Quit();
    }
}
