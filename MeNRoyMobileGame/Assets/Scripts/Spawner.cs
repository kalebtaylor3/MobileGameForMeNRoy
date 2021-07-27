using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] GoodShapes;

    private float distance;
    private float distanceMoved;

    bool movingup;
    bool movingRight;

    private void Update()
    {
        if (distance < transform.position.x + 5)
        {
            distance = transform.position.x + 5;
            movingRight = true;
            movingup = false;
        }
        else if (distance < transform.position.y + 60)
        {
            distance = transform.position.y + 60;
            movingup = true;
            movingRight = false;
            Debug.Log("moving up");
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
            Vector2 posToSpawnShape = new Vector2(transform.position.x + 10, transform.position.y -15);

            Instantiate(enemyToSpawn, posToSpawnShape, Quaternion.identity);
        }
    }

    private GameObject SelectShapeToSpawn()
    {
        int stage = UnityEngine.Random.RandomRange(0, 8);

        switch(stage)
        {
            case 0:
                return GoodShapes[0];
                break;
            case 1:
                return GoodShapes[1];
                break;
            case 2:
                return GoodShapes[2];
                break;
            case 3:
                return GoodShapes[3];
                break;
            case 4:
                return GoodShapes[4];
                break;
            case 5:
                return GoodShapes[5];
                break;
            case 6:
                return GoodShapes[6];
                break;
            case 7:
                return GoodShapes[7];
                break;
            case 8:
                return GoodShapes[8];
                break;
            default:
                return GoodShapes[0];
        }

    }
}
