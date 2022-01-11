using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private CanvasGroup mainButtons;
    [SerializeField] private CanvasGroup shopUI;
    [SerializeField] private CanvasGroup[] gameHud;
    //[SerializeField] private CanvasGroup statisticsUI;
    //[SerializeField] private CanvasGroup disableAdsUI;

    public static event Action OnShop;

    private void Awake()
    {
        shopUI.alpha = 0;
        //statisticsUI.alpha = 0;
        //disableAdsUI.alpha = 0;
        mainButtons.alpha = 0;

        shopUI.gameObject.SetActive(false);
    }

    private void Start()
    {
        mainButtons.alpha = Mathf.Lerp(0, 1, 2 / Time.deltaTime);
    }

    public void ShopButton()
    {
        shopUI.gameObject.SetActive(true);
        FreezeTime();
        mainButtons.alpha = Mathf.Lerp(1, 0, 2 / Time.deltaTime);

        for(int i = 0; i < gameHud.Length; i++)
        {
            gameHud[i].alpha = 0;
        }

        shopUI.alpha = Mathf.Lerp(0, 1, 2 / Time.deltaTime);
        //mainButtons.gameObject.SetActive(false);
    }

    void FreezeTime()
    {
        OnShop?.Invoke();
    }

}
