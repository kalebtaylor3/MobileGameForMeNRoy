using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinManager : MonoBehaviour, IstoreCoinManager
{
    public static event Action <Items.ItemType> OnChangeHat;

    public int currentNumberOfCoins = 10000;

    public void BoughtItem(Items.ItemType itemType)
    {
        Debug.Log("Bought item: " + itemType);
        OnChangeHat?.Invoke(itemType);
    }

    public bool TrySpendCoins(int coinAmmount)
    {
        if(coinAmmount > currentNumberOfCoins)
            return false;
        else
        {
            currentNumberOfCoins = currentNumberOfCoins - coinAmmount;
            Debug.Log("Youve Spent: " + coinAmmount);
            return true;
        }
    }
}
