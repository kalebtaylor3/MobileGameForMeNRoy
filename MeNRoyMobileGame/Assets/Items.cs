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
        Hat10
    }

    public static int GetCost(ItemType itemType)
    {
        switch(itemType)
        {
            default:
            case ItemType.Hat1: return 100;
            case ItemType.Hat2: return 100;
            case ItemType.Hat3: return 100;
            case ItemType.Hat4: return 100;
            case ItemType.Hat5: return 100;
            case ItemType.Hat6: return 100;
            case ItemType.Hat7: return 100;
            case ItemType.Hat8: return 100;
            case ItemType.Hat9: return 100;
            case ItemType.Hat10: return 100;
        }
    }

   public static Sprite GetSprite(ItemType itemtype)
    {
        switch(itemtype)
        {
            default:
            case ItemType.Hat1: return ShopAssets.i.Hat1;
            case ItemType.Hat2: return ShopAssets.i.Hat2;
            case ItemType.Hat3: return ShopAssets.i.Hat3;
            case ItemType.Hat4: return ShopAssets.i.Hat4;
            case ItemType.Hat5: return ShopAssets.i.Hat5;
            case ItemType.Hat6: return ShopAssets.i.Hat6;
            case ItemType.Hat7: return ShopAssets.i.Hat7;
            case ItemType.Hat8: return ShopAssets.i.Hat8;
            case ItemType.Hat9: return ShopAssets.i.Hat9;
            case ItemType.Hat10: return ShopAssets.i.Hat10;
        }
    }

}
