using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoodShape : MonoBehaviour
{
    public static event Action OnGoodShape;
    public static event Action<int, Transform> OnScoreIncrease;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnGoodShape?.Invoke();
            this.gameObject.SetActive(false);
            OnScoreIncrease.Invoke(50, this.transform);
        }
    }
}
