using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomShape : MonoBehaviour
{
    public static event Action OnRandom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnRandom?.Invoke();
    }
}
