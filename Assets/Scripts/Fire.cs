using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Oxygen oxygen;
    public float health = 100f;
    private float timer = 20f;
    private bool canExplode = true;

    private void Start()
    {
        health = 100f;
        oxygen = GameObject.FindObjectsOfType<Oxygen>()[0];
        oxygen.canDecreaseCount = true;
        Invoke("EndGame",timer);
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
        canExplode = false;
        Destroy(gameObject);
    }

    private void EndGame()
    {
        if(!canExplode) return;
        EndingManager.instance.DeathDueToSuffocation("YOU DIED\n DUE TO A EXPLOSION");
    }
}
