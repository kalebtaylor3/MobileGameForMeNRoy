using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GiveJump : MonoBehaviour
{
    public static event Action OnWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnWall?.Invoke();
    }
}
