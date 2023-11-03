using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    [SerializeField] int playScreen, menuScreen;
    public void LoadPlayScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(playScreen);
        Resume();
    }

    public void LoadMenuScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(menuScreen);
        Resume();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
