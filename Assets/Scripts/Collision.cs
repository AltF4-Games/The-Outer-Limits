using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject ship;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != ship && !other.transform.IsChildOf(ship.transform))
        {
            EndingManager.instance.Crashed("YOU DIED.\nYou crashed your spacecraft");
        }
    }
}
