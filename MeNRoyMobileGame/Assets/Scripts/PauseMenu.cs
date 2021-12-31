using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject pauseGO;

    public static event Action OnPause;
    public static event Action OnResume;

    public void Start()
    {
        pauseGO.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        OnPause?.Invoke();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        OnResume?.Invoke();
        Time.timeScale = 1f;
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

}
