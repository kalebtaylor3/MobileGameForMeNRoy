using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    #region VARIABLES
    public float launchPower;
    private Rigidbody2D rb;
    private Vector2 dragStartPosition;
    public Vector3 defaultScale;
    bool canJump = true;
    #endregion

    #region EVENTS
    public static event Action<bool> OnDrag;
    public static event Action OnEndDrag;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GoodShape.OnGoodShape += CanJump;
        BadShape.OnBadShape += EndGame;
        defaultScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButton(0) && canJump)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(3.6864f, 3, 3.6864f), 0.5f);
            OnDrag?.Invoke(canJump);
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.localScale = Vector3.Lerp(transform.localScale, defaultScale, 0.5f);
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

    private void OnEnable()
    {
        GoodShape.OnGoodShape += CanJump;
        BadShape.OnBadShape += EndGame;
    }

    private void OnDisable()
    {
        GoodShape.OnGoodShape -= CanJump;
        BadShape.OnBadShape -= EndGame;
    }
}
