using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidFieldGenerator : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public Vector3 fieldSize = new Vector3(100, 100, 100);
    public int asteroidCount = 100;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, fieldSize);
    }

    void GenerateAsteroidField()
    {
        for (int i = 0; i < asteroidCount; i++)
        {
            Vector3 randomPosition = transform.position + new Vector3(
                Random.Range(-fieldSize.x / 2, fieldSize.x / 2),
                Random.Range(-fieldSize.y / 2, fieldSize.y / 2),
                Random.Range(-fieldSize.z / 2, fieldSize.z / 2)
            );
            GameObject asteroidPrefab = asteroidPrefabs[Random.Range(0,asteroidPrefabs.Length)];
            GameObject go = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity,transform);
            go.name = "Asteroid";
        }
    }

    void Start()
    {
        GenerateAsteroidField();
    }
}
