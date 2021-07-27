using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GoodShape, BadShape, RandomShape;

    private float distance;
    private float distanceMoved;

    private void Update()
    {
        if (distance < transform.position.x + 40)
            distance = transform.position.x + 40;


        float distToGo = Mathf.Floor(distance - distanceMoved);

        if(distanceMoved < distance && distToGo > 15)
        {
            distanceMoved = distance;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = SelectShapeToSpawn();

        float yPos = Mathf.Floor(Mathf.Abs(UnityEngine.Random.Range(0, 10) - UnityEngine.Random.Range(0, 10)) * (1 + 20 - (-20)) + (-20));
        Vector2 posToSpawnShape = new Vector2(transform.position.x + 20, transform.position.y + 20);

        Instantiate(enemyToSpawn, posToSpawnShape, Quaternion.identity);
    }

    private GameObject SelectShapeToSpawn()
    {
        return GoodShape;
    }
}
