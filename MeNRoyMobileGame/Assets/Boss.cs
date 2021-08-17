using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;
    private Rigidbody2D rb;
    public GameObject fireball;

    float fireRate;
    float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        fireRate = 3f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // BOSS ROTATION TOWARDS PLAYER //

        Vector3 direction = player.position - transform.position;
        //Debug.Log(direction);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        //            FIN             //



    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
