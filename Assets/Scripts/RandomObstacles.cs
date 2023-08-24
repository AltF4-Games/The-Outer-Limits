using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacles : MonoBehaviour
{
    public string[] obstacleIDs;
    public GameObject obstaclePrefab;
    public Transform shipT;

    public void SpawnRandomObstacle(float n)
    {
        GameObject go = Instantiate(obstaclePrefab,shipT.position,Quaternion.identity);
        go.name = obstacleIDs[Random.Range(0,obstacleIDs.Length)];
        Destroy(go,n);
    }
}
