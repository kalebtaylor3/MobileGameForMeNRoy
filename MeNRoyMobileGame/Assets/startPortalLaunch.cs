using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPortalLaunch : MonoBehaviour
{

    public PlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        playerControl.rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
    }
}
