using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPortalLaunch : MonoBehaviour
{

    public PlayerControl playerControl;

    private void OnEnable()
    {
        FollowCamera.OnPortal += Portal;
    }

    private void OnDisable()
    {
        FollowCamera.OnPortal -= Portal;
    }

    private void Portal()
    {
        playerControl.rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
    }
}
