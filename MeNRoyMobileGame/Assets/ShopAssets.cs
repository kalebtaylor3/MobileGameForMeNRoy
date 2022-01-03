using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAssets : MonoBehaviour
{
    private static ShopAssets _i;

    public static ShopAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<ShopAssets>("ShopAssets"));
            return _i;
        }
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
}
