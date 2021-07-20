using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeAlter : MonoBehaviour
{
    // Start is called before the first frame update
    public float slowDownFactor = 0.2f;

    void Start()
    {
        PlayerControl.OnDrag += SlowDownTime;
        PlayerControl.OnEndDrag += SpeedUpTime;
    }

    void SlowDownTime(bool canSlow)
    {
        if(canSlow)
        {
            Time.timeScale = slowDownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.01f;
        }
    }

    void SpeedUpTime()
    {
        Time.timeScale = 1.0f;
    }

    private void OnDisable()
    {
        PlayerControl.OnDrag -= SlowDownTime;
    }
}
