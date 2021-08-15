using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{

    public Transform spawnPos;
    public Transform finishPos;
    public GameObject walls;

    public GameObject bossPrefab;
    private void Start()
    {
        walls.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //StartCoroutine(activateWalls());
        //StartCoroutine(activateWalls());
        walls.SetActive(true);
        Debug.Log("Spawned Boss");

        GameObject go;

        go = Instantiate(bossPrefab) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = spawnPos.position;
    }
}
