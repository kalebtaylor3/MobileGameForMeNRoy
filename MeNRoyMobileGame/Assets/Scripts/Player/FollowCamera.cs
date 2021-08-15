﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public float followSpeed;
    public Vector3 offSet;
    private Vector3 velocity = Vector3.one;

    public float maxSize = 15;
    public float minSize = 7.0f;

    public float maxXOffset = 26.2f;
    public float minXOffset = -26.2f;


    Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();    
    }

    private void LateUpdate()
    {
        if(velocity.y > 5 || velocity.y < -5)
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, maxSize, 0.0125f);
        else
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, minSize, 0.0125f);

        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
        smoothedPosition.x = Mathf.Clamp(target.position.x, minXOffset, maxXOffset);

        transform.position = smoothedPosition;
    }
}
