using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameStages
{
    STAGE_INIT = -1,
    STAGE_1,
    STAGE_END,
    MAX_STAGES
}

public class GameManager : MonoBehaviour
{
    //Used for bounds checks for the main player. 
    //You may need to change these if your player has a dramatically different size or odd proportions. 
    public static float MIN_X = -8;
    public static float MAX_X = 8;
    public static float MIN_Y = -4;
    public static float MAX_Y = 4;

    public bool gameHasEnded = false;

    public float restartDelay = 1f;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        GameEnd();
        EndGame();
    }

    //instance for the GameManager
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            if (!instance)
            {
                Debug.LogError("No Game Manager Present !!!");
            }

            return instance;

        }
    }

    [SerializeField]
    private GameStages gameStage = GameStages.STAGE_INIT;
    public GameStages GameStage
    {
        get { return gameStage; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        BadShape.OnBadShape += EndGame;
    }

    private void OnDisable()
    {
        BadShape.OnBadShape -= EndGame;
    }

    void Update()
    {
        UpdateStage();
    }

    /// <summary>
    /// Updates the current stage based on the time or whether a boss needs to be destroyed
    /// </summary>
    private void UpdateStage()
    {
        if (gameStage == GameStages.STAGE_END)
        {
            return;
        }
    }
    /// <summary>
    /// Called when the game is started from Main Menu exclusively
    /// </summary>
    public static void MainMenuGameStart()
    {
        instance.gameStage = GameStages.STAGE_1;
    }

    /// <summary>
    /// Called when the game is ended
    /// </summary>
    public void GameEnd()
    {

        //if score is higher than previous high score than replace it with current score value

        gameStage = GameStages.STAGE_END;
        UIManager.Instance.ShowGameOVer(true);

    }

    /// <summary>
    /// Called when the game is restarted.
    /// </summary>
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Called when the game is shut down from game over menu.
    /// </summary>
    public static void GameQuit()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    /// <summary>
    /// Returns true if the game is in a End game state.
    /// </summary>
    public static bool GameOver()
    {
        return instance.gameStage == GameStages.STAGE_END;
    }
}