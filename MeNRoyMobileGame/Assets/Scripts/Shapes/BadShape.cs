using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BadShape : MonoBehaviour
{
    public static event Action OnBadShape;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            OnBadShape?.Invoke();
            //this.gameObject.SetActive(false);
    }
}
