using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public float followSpeed;
    public Vector3 offSet;
    private Vector3 velocity = Vector3.one;

    public float maxSize = 15;
    float minSize = 7.0f;
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
        transform.position = smoothedPosition;
    }
}
