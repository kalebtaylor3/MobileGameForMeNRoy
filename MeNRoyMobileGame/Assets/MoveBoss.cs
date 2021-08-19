using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoss : MonoBehaviour
{
    private bool shouldMove = false;

    private float timeStartedMoving;
    public float lerpTime;

    public Vector2 endPosition;
    private Vector2 startPoisition;

    void Start()
    {
        startPoisition = transform.position;
        StartMoving();
    }

    private void StartMoving()
    {
        timeStartedMoving = Time.time;
        shouldMove = true;
    }

    void Update()
    {
        if (shouldMove)
        {
            transform.position = Move(startPoisition, startPoisition + endPosition, timeStartedMoving, lerpTime);
        }
    }

    public Vector3 Move(Vector3 start, Vector3 end, float timeStartedMoving, float lerpTime)
    {
        float timeSinceStarted = Time.time - timeStartedMoving;
        float percentageComplete = timeSinceStarted / lerpTime;
        var result = Vector3.Lerp(start, end, percentageComplete);
        return result;
    }
}
