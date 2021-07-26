using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    #region VARIABLES
    public float launchPower;
    public Rigidbody2D rb;
    private Vector2 dragStartPosition;
    bool canJump = true;
    #endregion

    #region EVENTS
    public static event Action<bool> OnDrag;
    public static event Action OnEndDrag;
    #endregion

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButton(0))
            OnDrag?.Invoke(canJump);

        if (Input.GetMouseButtonUp(0))
        {
            OnEndDrag?.Invoke();
            LaunchPlayer();
        }
    }

    void LaunchPlayer()
    {
        if(canJump)
        {
            Vector2 dragEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerVelocity = (dragEndPosition - dragStartPosition) * launchPower;

            rb.velocity = playerVelocity;
            canJump = false;
        }
    }

    void CanJump()
    {
        canJump = true;
    }

    void EndGame()
    {
        GetComponent<GameManager>();
    }

    void DisablePlayer()
    {
        this.gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        GoodShape.OnGoodShape += CanJump;
        BadShape.OnBadShape += EndGame;
        BadShape.OnBadShape += DisablePlayer;
        RandomShape.OnRandom += CanJump;
    }

    private void OnDisable()
    {
        GoodShape.OnGoodShape -= CanJump;
        BadShape.OnBadShape -= EndGame;
        BadShape.OnBadShape -= DisablePlayer;
        RandomShape.OnRandom -= CanJump;
    }
}
