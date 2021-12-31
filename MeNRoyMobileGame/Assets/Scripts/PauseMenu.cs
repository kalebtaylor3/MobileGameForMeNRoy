using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    public static event Action OnPause;
    public static event Action OnResume;


    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        OnPause?.Invoke();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        OnResume?.Invoke();
    }

}
