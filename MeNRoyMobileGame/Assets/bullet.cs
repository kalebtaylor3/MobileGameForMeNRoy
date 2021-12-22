using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bullet : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rb;

    [SerializeField] private Transform player;

    Vector2 moveDirection;

    private float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveDirection = (player.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Attack()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // Spawn Bullet or whatever else
        }
    }

}
