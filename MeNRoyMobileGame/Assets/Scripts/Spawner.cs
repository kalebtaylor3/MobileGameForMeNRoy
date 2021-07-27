using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject GoodShape, BadShape, RandomShape;

    private float distance;
    private float distanceMoved;

    bool movingup;
    bool movingRight;

    private void Update()
    {
        if (distance < transform.position.x + 20)
        {
            distance = transform.position.x + 20;
            movingRight = true;
            movingup = false;
        }
        else if (distance < transform.position.y + 40)
        {
            distance = transform.position.y + 40;
            movingup = true;
            movingRight = false;
        }

        if (movingup || movingRight)
        {
            float distToGo = Mathf.Floor(distance - distanceMoved);

            if (distanceMoved < distance && distToGo > 12)
            {
                distanceMoved = distance;
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = SelectShapeToSpawn();

        if (movingup)
        {
            Vector2 posToSpawnShape = new Vector2(transform.position.x, transform.position.y + 25);

            Instantiate(enemyToSpawn, posToSpawnShape, Quaternion.identity);
        }
        else if(movingRight)
        {
            Vector2 posToSpawnShape = new Vector2(transform.position.x + 15, transform.position.y);

            Instantiate(enemyToSpawn, posToSpawnShape, Quaternion.identity);
        }
    }

    private GameObject SelectShapeToSpawn()
    {
        return GoodShape;
    }
}
