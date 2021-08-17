using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float moveSpeed = 7f;

    Rigidbody2D rb;

    Transform player;

    Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (player.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
