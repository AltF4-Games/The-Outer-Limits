using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2f;
    [SerializeField] private KeyCode interactKey = KeyCode.E;

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(interactKey))
        {
            if(Physics.Raycast(transform.position,transform.forward,out hit, maxDistance,LayerMask.GetMask("Interact")))
            {
                if(hit.collider.gameObject.CompareTag("PilotSeat"))
                {
                    hit.collider.GetComponent<Pilot>().SwitchViews(true);
                }
            }
        }
    }
}