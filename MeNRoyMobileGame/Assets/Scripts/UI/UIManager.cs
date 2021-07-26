using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }

            if (!instance)
            {
                Debug.LogError("No UI Manager Present !!!");
            }

            return instance;

        }
    }
    [SerializeField]
    private GameObject endMenu;
    [SerializeField]
    private GameObject gameHUD;

    [Header("Game Over Settings")]
    [SerializeField]
    private Text resultText;
    [SerializeField]
    private Text finalScoreText;
    [SerializeField]
    private Text playAgainText;
    [SerializeField]
    private string victoryMessage = "Congratulations. You won!";
    [SerializeField]
    private string failMessage = "Sorry. You lost!";
    [SerializeField]
    private string finalScoreMessage = "Your final score is: ";
    [SerializeField]
    private string playAgainMessage = "Would you like to play again?";


    [Header("Fade Settings")]
    [SerializeField]
    private float hudFadeTimeScale = 1.0f;
    [SerializeField]
    private float mainMenuFadeTimeScale = 1.5f;
    [SerializeField]
    private float endMenuFadeTimeScale = 1.5f;

    private Coroutine hudFadeCoroutine = null;
    private Coroutine mainMenuFadeCoroutine = null;
    private Coroutine endMenuFadeCoroutine = null;

    public Text HighScoreText;

    int highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


        highScore = PlayerPrefs.GetInt("HighScore");

    }

    private void Start()
    {
        ShowEndMenu(false, true, false);
        ShowGameHUD(true, false);
    }

    /// <summary>
    /// Handle event the start of the game.
    /// </summary>
    public void HandleStartGame()
    {
        GameManager.MainMenuGameStart();
        ShowGameHUD(true, false);
    }


    /// <summary>
    /// Handle user interface for the end of the game.
    /// </summary>
    public void ShowGameOVer(bool victory)
    {
        ShowEndMenu(true, false, victory);
    }

    /// <summary>
    /// Handle menu visibility when the game is restarted.
    /// </summary>
    public void RestartGame()
    {
        ShowEndMenu(false, false, false);
        ShowGameHUD(true, false);
        GameManager.Instance.GameRestart();
    }

    /// <summary>
    /// Handle event for exiting game.
    /// </summary>
    public void QuitGame()
    {
        GameManager.GameQuit();
    }

    /// <summary>
    /// Helper function for togglind End Game Menu visibility.
    /// </summary>
    private void ShowEndMenu(bool show, bool immediate, bool victory)
    {
        if (endMenu)
        {
            if (show)
            {
                if (resultText)
                {
                    if (victory)
                    {
                        resultText.text = victoryMessage;
                    }
                    else
                    {
                        resultText.text = failMessage;
                    }

                }

                if (finalScoreText)
                {
                    //if score is greather than highscore then make final score message be "New High Score"

                    if(Score.scoreValue > highScore)
                    {
                        Debug.Log("hi");
                        finalScoreText.text = "New High Score!! : " + Score.scoreValue.ToString();
                        HighScoreText.text = "HighScore: " + Score.scoreValue.ToString();
                    }
                    else
                    {
                        finalScoreText.text = finalScoreMessage + Score.scoreValue.ToString();
                        HighScoreText.text = "HighScore: " + highScore;
                    }
                }

                if (playAgainText)
                {
                    playAgainText.text = playAgainMessage;
                }
            }


            endMenu.SetActive(show);

            CanvasGroup canvasGroupEndMenu = endMenu.GetComponent<CanvasGroup>();
            if (canvasGroupEndMenu && !immediate)
            {
                if (endMenuFadeCoroutine != null)
                {
                    StopCoroutine(endMenuFadeCoroutine);
                    endMenuFadeCoroutine = null;
                }

                endMenuFadeCoroutine = StartCoroutine(FadeCanvasGroup(endMenu, canvasGroupEndMenu, show, endMenuFadeTimeScale, immediate));
            }
            else
            {
                endMenu.SetActive(show);
            }
        }
    }

    /// <summary>
    /// Helper function for toggling HUD visibility.
    /// </summary>
    private void ShowGameHUD(bool show, bool immediate)
    {
        if (gameHUD)
        {
            CanvasGroup canvasGroupHUD = gameHUD.GetComponent<CanvasGroup>();
            if (canvasGroupHUD && !immediate)
            {
                if (hudFadeCoroutine != null)
                {
                    StopCoroutine(hudFadeCoroutine);
                    hudFadeCoroutine = null;
                }
                hudFadeCoroutine = StartCoroutine(FadeCanvasGroup(gameHUD, canvasGroupHUD, show, hudFadeTimeScale, immediate));
            }
            else
            {
                gameHUD.SetActive(show);
            }

        }
    }

    /// <summary>
    /// Coroutine for fading the alpha of a canvas group up or down
    /// </summary>
    private IEnumerator FadeCanvasGroup(GameObject canvasGO, CanvasGroup canvasGroup, bool show, float timeScale, bool immediate)
    {
        if (show)
        {
            canvasGroup.alpha = 0;
            canvasGO.SetActive(true);

            while (!immediate && canvasGroup && canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime * timeScale;
                yield return null;
            }
            canvasGroup.alpha = 1;
        }
        else
        {
            canvasGO.SetActive(true);
            while (!immediate && canvasGroup && canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime * timeScale;
                yield return null;
            }
            canvasGroup.alpha = 0;
            canvasGO.SetActive(false);

        }

    }
    /// <summary>
    /// Helper function displaying the game time.
    /// </summary>
    private string FormatTimeToString(int time)
    {
        string timeString = "0";

        if (time < 10)
        {
            timeString = "00" + time;
        }
        else if (time < 100)
        {
            timeString = "0" + time;
        }
        else if (time < 1000)
        {
            timeString = "" + time;
        }

        return timeString;
    }
}
