using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private Transform playerTransform;

    private float spawnX = 0.0f;
    private float spawnY = 0.0f;

    private float tileLength = 20.0f;
    private int tilesOnScreen = 3;

    private List<GameObject> activeTiles;

    private float dontDelete = 20.0f;

    private int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.x - dontDelete > (spawnX - tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
       
       /* if(playerTransform.position.y - dontDelete > (spawnY - tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
       */
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = transform.right * spawnX;
        spawnX += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}