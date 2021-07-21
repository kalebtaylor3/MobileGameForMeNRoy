using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StopWatchScore : MonoBehaviour
{
    bool stopWatchActive = false;
    float currentTime;
    public Text currentTimeText;

    int score;
    public Text scoreText;
    public float multiplier = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        score = Mathf.RoundToInt(currentTime * multiplier);
        scoreText.text = score.ToString();
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StartStopWatch()
    {
        stopWatchActive = true;
    }

    public void StopStopWatch()
    {
        stopWatchActive = false;
    }


}
