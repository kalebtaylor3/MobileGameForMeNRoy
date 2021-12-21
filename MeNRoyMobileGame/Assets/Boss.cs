using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    private Transform player;
    private Transform boss;
    private Rigidbody2D rb;
    public GameObject fireball;

    public static event Action OnBossDeath;

    float fireRate;
    float nextFire;

    [SerializeField]
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        fireRate = 3f;
        nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // BOSS ROTATION TOWARDS PLAYER //
        /*
        Vector3 direction = player.position - transform.position;
        //Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        */
        //            FIN             //
        if (player.position.x > boss.position.x)
        {
            if (mySpriteRenderer != null)
            {
                mySpriteRenderer.flipX = true;
            }
        }
        else
        {
            if (mySpriteRenderer != null)
            {
                mySpriteRenderer.flipX = false;
            }
        }

        Shoot();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Death();
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    void Death()
    {
        OnBossDeath?.Invoke();
    }
}
