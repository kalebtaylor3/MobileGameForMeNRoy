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
    private int multiplierScore;
    public Text multiplierText;


    private void Update()
    {
        IncreaseScoreByTime();
    }

    void IncreaseScore(int Amount)
    {
        if (multiplierScore == 0)
        {
            multiplierText.text = " ";
            scoreValue += Amount;
            multiplierScore = 1;
            StartCoroutine(MultilpierCoolDown());
        }
        else if(multiplierScore == 1)
        {
            multiplierText.text = "x2";
            scoreValue += Amount * 2;
            multiplierScore = 2;
            StopCoroutine(MultilpierCoolDown());
        }
        else if(multiplierScore == 2)
        {
            multiplierText.text = "x4";
            scoreValue += Amount * 4;
            multiplierScore = 3;
            StopCoroutine(MultilpierCoolDown());
        }
        else if(multiplierScore == 3)
        {
            multiplierText.text = "x8";
            scoreValue += Amount * 8;
            multiplierScore = 4;
            StopCoroutine(MultilpierCoolDown());
        }
        else if (multiplierScore == 4)
        {
            multiplierText.text = "x16";
            scoreValue += Amount * 16;
            multiplierScore = 5;
            StopCoroutine(MultilpierCoolDown());
        }
        StartCoroutine(MultilpierCoolDown());
    }

    IEnumerator MultilpierCoolDown()
    {
        yield return new WaitForSeconds(4);
        multiplierScore = 0;
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
        multiplierText.text = " ";
        GoodShape.OnScoreIncrease += IncreaseScore;
        BadShape.OnBadShape += StopStopWatch;
        PlayerControl.OnDrag += StartStopWatch;
        scoreValue = 0;
        currentTime = 0;
    }

    private void OnDisable()
    {
        StopStopWatch();
        GoodShape.OnScoreIncrease -= IncreaseScore;
        PlayerControl.OnDrag -= StartStopWatch;
        BadShape.OnBadShape -= StopStopWatch;
    }
}
