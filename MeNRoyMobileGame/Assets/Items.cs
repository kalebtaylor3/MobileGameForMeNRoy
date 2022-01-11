using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
   public enum ItemType
    {
        Hat1,
        Hat2,
        Hat3,
        Hat4,
        Hat5,
        Hat6,
        Hat7,
        Hat8,
        Hat9,
        Hat10,
        Hat11,
        Hat12
    }

    public static int GetCost(ItemType itemType)
    {
        switch(itemType)
        {
            default:
            case ItemType.Hat1: return 1000;
            case ItemType.Hat2: return 3500;
            case ItemType.Hat3: return 2000;
            case ItemType.Hat4: return 10000;
            case ItemType.Hat5: return 100;
            case ItemType.Hat6: return 500;
            case ItemType.Hat7: return 7000;
            case ItemType.Hat8: return 9600;
            case ItemType.Hat9: return 3300;
            case ItemType.Hat10: return 5500;
            case ItemType.Hat11: return 2200;
            case ItemType.Hat12: return 1130;
        }
    }

   public static Sprite GetSprite(ItemType itemtype)
    {
        switch(itemtype)
        {
            default:
            case ItemType.Hat1: return ShopAssets.Instance.Hat1;
            case ItemType.Hat2: return ShopAssets.Instance.Hat2;
            case ItemType.Hat3: return ShopAssets.Instance.Hat3;
            case ItemType.Hat4: return ShopAssets.Instance.Hat4;
            case ItemType.Hat5: return ShopAssets.Instance.Hat5;
            case ItemType.Hat6: return ShopAssets.Instance.Hat6;
            case ItemType.Hat7: return ShopAssets.Instance.Hat7;
            case ItemType.Hat8: return ShopAssets.Instance.Hat8;
            case ItemType.Hat9: return ShopAssets.Instance.Hat9;
            case ItemType.Hat10: return ShopAssets.Instance.Hat10;
            case ItemType.Hat11: return ShopAssets.Instance.Hat11;
            case ItemType.Hat12: return ShopAssets.Instance.Hat12;
        }
    }

}
