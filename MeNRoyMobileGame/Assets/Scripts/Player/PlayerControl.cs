using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    #region VARIABLES
    public float launchPower;
    public Rigidbody2D rb;
    private Vector3 dragStartPosition;
    bool canJump = true;

    public Vector3 playerVelocity;
    #endregion

    #region EVENTS
    public static event Action<bool> OnDrag;
    public static event Action OnEndDrag;
    #endregion

    private void Update()
    {
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
            dragStartPosition = transform.position;

            rb.velocity = new Vector2(0,0);

            Vector3 dragEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerVelocity = (dragEndPosition - dragStartPosition) * launchPower;

            rb.AddForce(playerVelocity, ForceMode2D.Impulse);
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
        GiveJump.OnWall += CanJump;
    }

    private void OnDisable()
    {
        GoodShape.OnGoodShape -= CanJump;
        BadShape.OnBadShape -= EndGame;
        BadShape.OnBadShape -= DisablePlayer;
        RandomShape.OnRandom -= CanJump;
    }
}
