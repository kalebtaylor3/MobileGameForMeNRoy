using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


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

    bool paused = false;

    public SpriteRenderer playerHat;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (!paused)
            {
                if (Input.GetMouseButton(0))
                    OnDrag?.Invoke(canJump);

                if (Input.GetMouseButtonUp(0))
                {
                    OnEndDrag?.Invoke();
                    LaunchPlayer();
                }
            }
            else
            {
                return;
            }
        }
    }

    void Pause()
    {
        paused = true;
    }
    void Resume()
    {
        paused = false;
    }

    void LaunchPlayer()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (canJump)
            {
                dragStartPosition = transform.position;

                rb.velocity = new Vector2(0, 0);

                Vector3 dragEndPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                playerVelocity = (dragEndPosition - dragStartPosition) * launchPower;

                rb.AddForce(playerVelocity, ForceMode2D.Impulse);
                canJump = false;
            }
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

    void ChangeHat(Items.ItemType itemType)
    {
        playerHat.sprite = Items.GetSprite(itemType);
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        GoodShape.OnGoodShape += CanJump;
        BadShape.OnBadShape += EndGame;
        BadShape.OnBadShape += DisablePlayer;
        RandomShape.OnRandom += CanJump;
        GiveJump.OnWall += CanJump;
        TriggerPortal.OnPortal += DisablePlayer;
        PauseMenu.OnPause += Pause;
        PauseMenu.OnResume += Resume;
        MainMenuButtons.OnShop += Pause;
        MainMenuButtons.OnDone += Resume;
        ReturnPortal.OnReturnPortal += CanJump;
        CoinManager.OnChangeHat += ChangeHat;
    }

    private void OnDisable()
    {
        GoodShape.OnGoodShape -= CanJump;
        BadShape.OnBadShape -= EndGame;
        BadShape.OnBadShape -= DisablePlayer;
        RandomShape.OnRandom -= CanJump;
        TriggerPortal.OnPortal -= DisablePlayer;
        PauseMenu.OnPause -= Pause;
        PauseMenu.OnResume -= Resume;
        MainMenuButtons.OnDone -= Resume;
        MainMenuButtons.OnShop -= Pause;
        ReturnPortal.OnReturnPortal -= CanJump;
        CoinManager.OnChangeHat -= ChangeHat;
    }
}
