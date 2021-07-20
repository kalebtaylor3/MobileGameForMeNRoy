using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int highScore = 0;
    public static int scoreValue = 0;
    Text score;
    Text highestScore;

    void IncreaseScore(int Amount)
    {
        scoreValue += Amount;
        score.text = "Score: " + scoreValue;
        highestScore.text = "Score: " + highScore;
    }

    private void OnEnable()
    {
        score = GetComponent<Text>();
        score.text = "Score: " + scoreValue;
        GoodShape.OnScoreIncrease += IncreaseScore;
    }

    private void OnDisable()
    {
        GoodShape.OnScoreIncrease -= IncreaseScore;
    }
}
