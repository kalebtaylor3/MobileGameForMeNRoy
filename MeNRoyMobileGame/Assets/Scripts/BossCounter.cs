using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCounter : MonoBehaviour
{

    public int spawnAtNumber = 4;

    private void OnEnable()
    {
        TileManagerReal.OnIncrease += Increase;
    }

    void Increase(TileManagerReal counter)
    {
        if(counter.bossCounter >= spawnAtNumber)
        {
            //either reset or unsubscribe
            counter.bossCounter = 0;
        }
        else
        {
            counter.bossCounter++;
        }
    }
}
