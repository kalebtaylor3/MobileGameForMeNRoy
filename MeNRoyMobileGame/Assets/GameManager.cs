using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public float restartDelay = 1f;

    private void OnEnable()
    {
        BadShape.OnBadShape += EndGame;
    }

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }    
    }    

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EndGame();
    }

}
