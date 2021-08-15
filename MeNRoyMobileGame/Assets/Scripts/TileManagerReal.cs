using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileManagerReal : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public GameObject BossTile;

    public Transform playerTransform;

    private float spawnY = 0.0f;
    private float tileLength = 20.0f;
    private float dontDelete = 20.0f;

    private int ytilesOnScreen = 7;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;

    public GameObject deathPrefab;

    public float deathYOffset = -20;
    [HideInInspector]
    public int bossCounter = 0;

    public static event Action<TileManagerReal> OnIncrease;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < ytilesOnScreen; i++)
        {
            if (i > 2)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y - dontDelete > (spawnY - ytilesOnScreen * tileLength))
        {
            //if the counter is less than 500 or something spawn normal tiles
            //if its greater than or = to 500 spawn boss tile and reset the counter

            OnIncrease?.Invoke(this);

            if(bossCounter < 1)
            {
                SpawnTile();
            }
            else if(bossCounter >= 1)
            {
                SpawnBossTile();
            }
            DeleteTile();
        }

        //loop through all active tiles
        //get the first tile in the list &  activate the death prefab underneath it

        Vector3 offset = new Vector3(0, deathYOffset, 0);

        deathPrefab.transform.position = activeTiles[0].transform.position + offset; 

    }

    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector2.up * spawnY;
        spawnY += tileLength;
        activeTiles.Add(go);
    }

    void SpawnBossTile()
    {
        GameObject go;

        go = Instantiate(BossTile) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector2.up * spawnY;
        spawnY += tileLength;
        activeTiles.Add(go);
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }   
    
    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = UnityEngine.Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
