using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System;

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

    bool inPortal = false;
    bool inReturn = false;

    private GameObject[] player;

    Vector3 currentVeolcity;


    public PlayerControl playerControl;

    private bullet fireBall;

    Camera cam;

    public static event Action OnPortal;


    private void Start()
    {
        cam = GetComponent<Camera>();
        bossFight = false;

        player = GameObject.FindGameObjectsWithTag("Player");
        fireBall = GameObject.FindObjectOfType<bullet>();

        DisablePortalPlayer();
    }

    private void OnEnable()
    {
        SpawnBoss.OnBoss += EnableBoss;
        Boss.OnBossDeath += DisableBoss;
        TriggerPortal.OnPortal += Portal;
        ReturnPortal.OnReturnPortal += OtherPortal;
    }

    private void OnDisable()
    {
        SpawnBoss.OnBoss -= EnableBoss;
        Boss.OnBossDeath -= DisableBoss;
        TriggerPortal.OnPortal -= Portal;
        ReturnPortal.OnReturnPortal -= OtherPortal;
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
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 12, 1);
            Vector3 desiredPosition = currentTarget.position + offSet;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
            smoothedPosition.x = Mathf.Clamp(currentTarget.position.x, minXOffset, maxXOffset);
            //smoothedPosition.y = Mathf.Clamp(target.position.x, minYOffset, maxYOffset);

            transform.position = smoothedPosition;

            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 15, 0.0125f);
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

        currentVeolcity = playerControl.playerVelocity;

        targets[0].gameObject.SetActive(false);


        followSpeed = 1;

        StartCoroutine(SlowPan());

        if(bossFight)
        {
            StartCoroutine(WaitForPlayer());
            StartCoroutine(WaitForScene());
            inPortal = false;
            inReturn = false;
        }
        else if(inPortal)
        {
            //generate random number to determin level and make the target the player from that level

            int num = Random.Range(0, 2);

            if(num == 0)
            {
                StartCoroutine(WaitForPortalAnimation(3));
            }
            if (num == 1)
            {
                StartCoroutine(WaitForPortalAnimation(4));
            }

            if (num == 2)
            {
                StartCoroutine(WaitForPortalAnimation(5));
            }


        }
        else if(inReturn)
        {
            StartCoroutine(WaitForPortalAnimation(0));
        }
    }

    void Portal()
    {
        inPortal = true;
        inReturn = false;
        Time.timeScale = 1;
    }

    void OtherPortal()
    {
        inReturn = true;
        inPortal = false;
        Time.timeScale = 1;
        DisablePortalPlayer();
        targets[0].transform.position = targets[2].transform.position;
    }

    void DisablePortalPlayer()
    {
        targets[3].gameObject.SetActive(false);
        targets[4].gameObject.SetActive(false);
        targets[5].gameObject.SetActive(false);
    }

    IEnumerator SlowPan()
    {
        yield return new WaitForSeconds(1.5f);
        followSpeed = 0.125f;
    }

    IEnumerator SlowPanToPlayer()
    {
        yield return new WaitForSeconds(0.9f);
        followSpeed = 0.125f;
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(5.8f);
        //player[0].SetActive(true);
        targets[0].gameObject.SetActive(true);
    }

    IEnumerator WaitForPortalAnimation(int index)
    {
        yield return new WaitForSeconds(3f);
        //followSpeed = 1;
        maxXOffset = 126.2f;
        minXOffset = -126.2f;
        StartCoroutine(WaitForPan());
        targets[index].gameObject.SetActive(true);
        currentTarget = targets[index];
        OnPortal?.Invoke();

        if(inReturn)
        {
            maxXOffset = 26.2f;
            minXOffset = -26.2f;
        }

        playerControl.rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        inReturn = false;
        inPortal = false;
    }

    IEnumerator WaitForPan()
    {
        yield return new WaitForSeconds(3f);
        //followSpeed = 0.5f;
    }

    IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(6);
        currentTarget = targets[0];
        followSpeed = 1f;
        StartCoroutine(SlowPanToPlayer());
    }
}
