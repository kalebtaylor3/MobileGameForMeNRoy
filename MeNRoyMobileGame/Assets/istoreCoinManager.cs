using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IstoreCoinManager
{
    void BoughtItem(Items.ItemType itemType);
    bool TrySpendCoins(int coinAmmount);
}
