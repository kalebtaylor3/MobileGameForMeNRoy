using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{
    public float launchPower;
    private Rigidbody2D rb;
    private Vector2 dragStartPosition;
    public static event Action<bool> OnDrag;
    public static event Action OnEndDrag;

    bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GoodShape.OnGoodShape += CanJump;
    }

    private void Update()
    {

        Debug.Log(canJump);

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
            //canJump = false;
        }
    }

    void CanJump()
    {
        canJump = true;
    }

}
