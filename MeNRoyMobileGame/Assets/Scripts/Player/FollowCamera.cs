﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform currentTarget;
    public Transform[] targets;

    public float followSpeed;
    public Vector3 offSet;
    private Vector3 velocity = Vector3.one;

    public float maxSize = 15;
    public float minSize = 7.0f;

    public float maxXOffset = 26.2f;
    public float minXOffset = -26.2f;

    bool bossFight = false;


    private GameObject[] player;

    Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();
        bossFight = false;

        player = GameObject.FindGameObjectsWithTag("Player");
    }

    private void OnEnable()
    {
        SpawnBoss.OnBoss += EnableBoss;
        Boss.OnBossDeath += DisableBoss;
    }

    private void OnDisable()
    {
        SpawnBoss.OnBoss -= EnableBoss;
        Boss.OnBossDeath -= DisableBoss;
    }

    private void LateUpdate()
    {
        if (!bossFight)
        {
            if (velocity.y > 10 || velocity.y < -10)
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxSize, 0.0125f);
            else
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, minSize, 0.0125f);

            Vector3 desiredPosition = currentTarget.position + offSet;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
            smoothedPosition.x = Mathf.Clamp(currentTarget.position.x, minXOffset, maxXOffset);

            transform.position = smoothedPosition;
        }
        else if(bossFight == true)
        {
            Vector3 desiredPosition = currentTarget.position + offSet;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
            smoothedPosition.x = Mathf.Clamp(currentTarget.position.x, minXOffset, maxXOffset);
            //smoothedPosition.y = Mathf.Clamp(target.position.x, minYOffset, maxYOffset);

            transform.position = smoothedPosition;

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, minSize, 0.0125f);
        }
    }

    void EnableBoss(float minX, float maX)
    {
        bossFight = true;
        maxXOffset = maX;
        minXOffset = minX;
    }

    void DisableBoss()
    {
        bossFight = false;
        maxXOffset = 26.2f;
        minXOffset = -26.2f;
    }

    public void SetTarget(int index, Transform newTarget)
    {
        targets[index] = newTarget;

        currentTarget = targets[index];

        StartCoroutine(WaitForScene());
    }

    IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(3);
        currentTarget = targets[0];
        player[0].SetActive(true);
    }
}
