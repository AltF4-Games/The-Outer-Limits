using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject ship;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Teleport")
        {
            EndingManager.instance.FinalEnding();
            return;
        }

        if (other.gameObject.tag == "IFF")
        {
            EndingManager.instance.doesHaveIFF = true;
            Destroy(other.gameObject);
            return;
        }

        if (other.tag == "Enemy" || other.tag == "Planet" || other.tag == "Satellite")
        {
            Debug.Log(other.gameObject.name);
            EndingManager.instance.Crashed("YOU DIED.\nYou crashed your spacecraft");
        }
    }
}
