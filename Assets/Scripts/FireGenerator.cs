using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private GameObject ship;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            GenerateFire();
    }

    public void GenerateFire()
    {
        GameObject fire = Instantiate(firePrefab,spawnLocations[Random.Range(0,spawnLocations.Length)].position,Quaternion.identity,spawnLocations[Random.Range(0,spawnLocations.Length)]);
    }
}
