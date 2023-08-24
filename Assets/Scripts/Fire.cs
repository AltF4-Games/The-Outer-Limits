using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Oxygen oxygen;
    public float health = 100f;

    private void Start()
    {
        health = 100f;
        oxygen = GameObject.FindObjectsOfType<Oxygen>()[0];
        oxygen.canDecreaseCount = true;
    }

    private void Update()
    {
        if(health <= 0)
        {
            ExtinguishFire();
        }
    }


    public void ExtinguishFire()
    {
        Destroy(gameObject);
    }
}
