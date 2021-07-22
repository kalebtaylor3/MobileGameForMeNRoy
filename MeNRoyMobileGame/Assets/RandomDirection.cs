using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class RandomDirection : MonoBehaviour
{

    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomShape.OnRandom += FirePlayer;
    }

    private void OnDisable()
    {
        RandomShape.OnRandom -= FirePlayer;
    }

    void FirePlayer()
    {
        rb.AddForce(Direction() * 5000, ForceMode2D.Force);
    }

    Vector2 Direction()
    {
        int randomNumber = Random.Range(0, 3);
        Vector2 Direction;

        switch(randomNumber)
        {
            case 0:
                Direction = Vector2.up;
                break;
            case 1:
                Direction = Vector2.down;
                break;
            case 2:
                Direction = Vector2.left;
                break;
            case 3:
                Direction = Vector2.right;
                break;
            default:
                Direction = Vector2.zero;
                break;
        }

        return Direction;
    }
}
