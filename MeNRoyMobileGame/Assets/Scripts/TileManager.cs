using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public Transform upDir;
    public Transform rightDir;
    public Transform playerTransform;

    private float spawnX = 0.0f;
    private float spawnY = 0.0f;

    private float tileLength = 20.0f;
    private int ytilesOnScreen = 2;
    private int xtilesOnScreen = 2;

    private List<GameObject> activeXTiles;
    private List<GameObject> activeYTiles;

    private float dontDelete = 20.0f;

    private int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeXTiles = new List<GameObject>();
        activeYTiles = new List<GameObject>();

        for(int i = 0; i < xtilesOnScreen; i++)
        {
            SpawnTileX(rightDir);
        }

        for (int i = 0; i < ytilesOnScreen; i++)
        {
            SpawnTileY(upDir);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < xtilesOnScreen -1; i++)
        {
            Destroy(activeXTiles[0]);
        }

        for (int i = 0; i < ytilesOnScreen -1; i++)
        {
            Destroy(activeYTiles[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.x - dontDelete > (spawnX - xtilesOnScreen * tileLength))
        {
            float totalCount = activeYTiles.Count + activeXTiles.Count;

            if (totalCount > 4)
            {
                Destroy(activeYTiles[1]);
            }

            SpawnTileX(rightDir);
            DeleteXTile();
        }

        if (playerTransform.position.y - dontDelete > (spawnY - ytilesOnScreen * tileLength))
        {
            float totalCount = activeYTiles.Count + activeXTiles.Count;

            if (totalCount > 4)
            {
                Destroy(activeXTiles[1]);
            }

            SpawnTileY(upDir);
            DeleteYTile();
        }
    }

    private void SpawnTileX(Transform Direction)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Direction.position;
        spawnX += tileLength;
        activeXTiles.Add(go);
    }

    private void SpawnTileY(Transform Direction)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Direction.position;
        spawnY += tileLength;
        activeYTiles.Add(go);
    }

    private void DeleteXTile()
    {
        Destroy(activeXTiles[0]);
        activeXTiles.RemoveAt(0);
    }
    private void DeleteYTile()
    {
        Destroy(activeYTiles[0]);
        activeYTiles.RemoveAt(0);
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