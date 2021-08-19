using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnBoss : MonoBehaviour
{

    public Transform spawnPos;
    public Transform finishPos;
    public GameObject walls;
    public GameObject bossPrefab;
    bool canSpawn = true;

    public static event Action<float, float> OnBoss;

    public float minX;
    public float maxX;

    private void OnEnable()
    {
        Boss.OnBossDeath += DisableWalls;
    }

    private void OnDisable()
    {
        Boss.OnBossDeath -= DisableWalls;
    }

    private void Start()
    {
        walls.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canSpawn)
        {
            OnBoss?.Invoke(minX, maxX);
            //StartCoroutine(activateWalls());
            //StartCoroutine(activateWalls());
            walls.SetActive(true);
            Debug.Log("Spawned Boss");

            GameObject go;

            go = Instantiate(bossPrefab) as GameObject;
            go.transform.SetParent(transform);
            go.transform.position = spawnPos.position;
            canSpawn = false;
        }
    }

    void DisableWalls()
    {
        //play animation
        StartCoroutine(waitForFade());
    }

    IEnumerator waitForFade()
    {
        yield return new WaitForSeconds(1);
        this.walls.SetActive(false);
    }
}
