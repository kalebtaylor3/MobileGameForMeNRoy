using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BadShape : MonoBehaviour
{
    public static event Action OnBadShape;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnBadShape?.Invoke();
        this.gameObject.SetActive(false);
        Score.scoreValue = Score.highScore;
        Score.scoreValue = 0;
    }
}
