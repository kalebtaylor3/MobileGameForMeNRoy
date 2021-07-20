using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoodShape : MonoBehaviour
{
    public static event Action OnGoodShape;
    public static event Action<int> OnScoreIncrease;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnGoodShape?.Invoke();
        this.gameObject.SetActive(false);
        OnScoreIncrease.Invoke(50);
    }
}
