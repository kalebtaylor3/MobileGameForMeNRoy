using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public static int highScore = 0;
    public static int scoreValue = 0;
    Text score;
    Text highestScore;
    public int DelayAmount = 1;
    bool stopWatchActive = false;
    protected float timer;
    public Text currentTimeText;
    float currentTime;


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
        {
            PlayerControl.OnDrag -= StartStopWatch;
            currentTime = currentTime + Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.ToString(@"mm\:ss\:fff");
            timer += Time.deltaTime;
        }

        if(timer >= DelayAmount)
        {
            timer = 0f;
            scoreValue += 10;
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
        currentTimeText.text = "00:00:00";
        score = GetComponent<Text>();
        score.text = "Score: " + scoreValue;
        GoodShape.OnScoreIncrease += IncreaseScore;
        PlayerControl.OnDrag += StartStopWatch;
    }

    private void OnDisable()
    {
        StopStopWatch();
        GoodShape.OnScoreIncrease -= IncreaseScore;
        PlayerControl.OnDrag -= StartStopWatch;
        scoreValue = 0;
        currentTime = 0;
    }
}
