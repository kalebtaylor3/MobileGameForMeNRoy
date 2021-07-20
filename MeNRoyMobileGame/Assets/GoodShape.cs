using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoodShape : MonoBehaviour
{
    public static event Action OnGoodShape;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnGoodShape?.Invoke();
        this.gameObject.SetActive(false);
    }
}
