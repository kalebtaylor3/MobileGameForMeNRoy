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
    float xHit = 0;

    [SerializeField]
    private SpriteRenderer mySpriteRenderer;

    [SerializeField]
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        fireRate = 3f;
        nextFire = Time.time;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WaitForScene());
        
    }

    IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(6);
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
                mySpriteRenderer.flipX = false;
            }
        }
        else
        {
            if (mySpriteRenderer != null)
            {
                mySpriteRenderer.flipX = true;
            }
        }

        Shoot();
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
  

        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("DamageIndicator", true);

            xHit++;
            if(xHit >= 3)
            {
                Debug.Log(xHit);
                Death();
            }
            StartCoroutine(Wait2());
        }

    }

    void Shoot()
    {
        //animator.SetBool("FireBall", true);
        if (Time.time > nextFire)
        {
  
            StartCoroutine(Wait());
            Instantiate(fireball, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
            animator.SetBool("FireBall", false);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("FireBall", true);
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("DamageIndicator", false);
    }



    void Death()
    {
        OnBossDeath?.Invoke();
    }
}
