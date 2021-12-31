using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlStart : MonoBehaviour
{

    public Rigidbody2D player;
    public CanvasGroup hud;
    public UIManager ui;

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
        player.constraints = RigidbodyConstraints2D.None;
        PlayerControl.OnEndDrag -= StartGame;
    }
}
