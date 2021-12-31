using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlStart : MonoBehaviour
{

    public Rigidbody2D player;
    public CanvasGroup hud;
    public UIManager ui;

    public static event Action<bool> OnTimer;

    // Start is called before the first frame update
    void Start()
    {
        player.constraints = RigidbodyConstraints2D.FreezePosition;
        hud.alpha = 0;
    }

    private void OnEnable()
    {
        PlayerControl.OnEndDrag += StartGame;
    }

    // Update is called once per frame
    void StartGame()
    {
        ui.ShowGameHUD(true, false);
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        OnTimer?.Invoke(true);
        PlayerControl.OnEndDrag -= StartGame;
    }
}
