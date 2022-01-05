using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Laser : MonoBehaviour
{
    public float angularSpeed = 1f;
    public float circleRad = 10f;

    [SerializeField]
    private Transform boss;

    private Vector2 fixedpointBOSS;
    private float currentAngle;

    private bool wait;

    void Start()
    {
        wait = false;
        StartCoroutine(WaitForScene());
    }

    void Update()
    {
        if(wait)
        {
            currentAngle += angularSpeed * Time.deltaTime;
            Vector2 offset = new Vector2(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle)) * circleRad;
            transform.position = fixedpointBOSS + offset;
        }
    }

    IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(7);
        //fixedpointBOSS = transform.position;
        wait = true;
    }
}
