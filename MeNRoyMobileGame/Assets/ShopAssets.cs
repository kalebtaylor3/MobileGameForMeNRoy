using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAssets : MonoBehaviour
{
    public static ShopAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite Hat1;
    public Sprite Hat2;
    public Sprite Hat3;
    public Sprite Hat4;
    public Sprite Hat5;
    public Sprite Hat6;
    public Sprite Hat7;
    public Sprite Hat8;
    public Sprite Hat9;
    public Sprite Hat10;
    public Sprite Hat11;
    public Sprite Hat12;
}
