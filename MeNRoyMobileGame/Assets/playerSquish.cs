using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerSquish : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 defaultScale;

    void SquishPlayer(bool canSquish)
    {
        if(canSquish)
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(3.6864f, 3, 3.6864f), 0.5f);
    }

    void NormalPlayer()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, 0.5f);
    }

    private void OnEnable()
    {
        PlayerControl.OnDrag += SquishPlayer;
        PlayerControl.OnEndDrag += NormalPlayer;
        defaultScale = transform.localScale;
    }

    private void OnDisable()
    {
        PlayerControl.OnDrag -= SquishPlayer;
        PlayerControl.OnEndDrag -= NormalPlayer;
    }
}
