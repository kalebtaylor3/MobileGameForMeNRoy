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
    public int DelayAmount = 1;
    bool stopWatchActive = false;
    protected float timer;


    private void Update()
    {
        IncreaseScoreByTime();
    }

    void IncreaseScore(int Amount)
    {
        scoreValue += Amount;
        //score.text = "Score: " + scoreValue;
        highestScore.text = "Score: " + highScore;
    }

    void IncreaseScoreByTime()
    {
        if(stopWatchActive)
            timer += Time.deltaTime;

        if(timer >= DelayAmount)
        {
            timer = 0f;
            scoreValue++;
        }
        score.text = "Score: " + scoreValue;
    }

    public void StartStopWatch(bool canDrag)
    {
        if(canDrag)
            stopWatchActive = true;
    }

    public void StopStopWatch()
    {
        stopWatchActive = false;
    }

    private void OnEnable()
    {
        score = GetComponent<Text>();
        score.text = "Score: " + scoreValue;
        GoodShape.OnScoreIncrease += IncreaseScore;
        PlayerControl.OnDrag += StartStopWatch;
    }

    private void OnDisable()
    {
        GoodShape.OnScoreIncrease -= IncreaseScore;
    }
}
