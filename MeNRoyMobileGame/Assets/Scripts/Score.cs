using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private static int highScore = 0;
    [SerializeField] public static int scoreValue = 0;
    Text score;
    Text highestScore;
    [SerializeField] private int DelayAmount = 1;
    bool stopWatchActive = false;
    protected float timer;
    [SerializeField] private Text currentTimeText;
    float currentTime;
    private int multiplierScore;
    [SerializeField] private Text multiplierText;

    [SerializeField] private GameObject floatingText;


    private void Update()
    {
        IncreaseScoreByTime();
    }

    void IncreaseScore(int Amount, Transform position)
    {

        GameObject prefabText = Instantiate(floatingText, position.position, Quaternion.identity);

        if (multiplierScore == 0)
        {
            multiplierText.text = " ";
            scoreValue += Amount;
            prefabText.GetComponentInChildren<TextMesh>().text = "+" + Amount.ToString();
            multiplierScore = 1;
            StartCoroutine("MultilpierCoolDown");
        }
        else if(multiplierScore == 1)
        {
            multiplierText.text = "x2";
            scoreValue += Amount * 2;
            int textAmount = Amount * 2;
            prefabText.GetComponentInChildren<TextMesh>().text = "+" + textAmount.ToString();
            multiplierScore = 2;
            StopCoroutine("MultilpierCoolDown");
        }
        else if(multiplierScore == 2)
        {
            multiplierText.text = "x4";
            scoreValue += Amount * 4;
            int textAmount = Amount * 4;
            prefabText.GetComponentInChildren<TextMesh>().text = "+" + textAmount.ToString();
            multiplierScore = 3;
            StopCoroutine("MultilpierCoolDown");
        }
        else if(multiplierScore == 3)
        {
            multiplierText.text = "x8";
            scoreValue += Amount * 8;
            int textAmount = Amount * 8;
            prefabText.GetComponentInChildren<TextMesh>().text = "+" + textAmount.ToString();
            StopCoroutine("MultilpierCoolDown");
        }
        StartCoroutine("MultilpierCoolDown");
    }

    IEnumerator MultilpierCoolDown()
    {
        yield return new WaitForSeconds(0.75f);
        multiplierScore = 0;
        multiplierText.text = " ";
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
        score.text = "SCORE: " + scoreValue;
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
        score.text = "SCORE: " + scoreValue;
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
        multiplierScore = 0;
        multiplierText.text = " ";
    }
}
