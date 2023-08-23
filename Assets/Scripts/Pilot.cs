using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent (typeof (Interactable))]
public class Pilot : MonoBehaviour
{
    public Transform pilotCameraRoot;
    public Transform playerCameraRoot;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public SpaceshipMovement movement;
    public StarterAssets.FirstPersonController controller;
    public Interact interact;
    public GameObject canvas;
    public KeyCode key = KeyCode.Escape;
    private bool inSeat = false;

    public void SwitchViews(bool val)
    {
        if(val) {
            cinemachineVirtualCamera.Follow = pilotCameraRoot;
            inSeat = true;
            movement.canDrive = true;
            controller.enabled = false;
            interact.enabled = false;
            canvas.SetActive(false);
        } 
        else {
            controller.enabled = true;
            cinemachineVirtualCamera.Follow = playerCameraRoot;
            inSeat = false;
            movement.canDrive = false;
            canvas.SetActive(true);
            interact.enabled = true;
        }
    }

    private void Update()
    {
        if(inSeat) 
        {
            if(Input.GetKey(key)) 
            {
                SwitchViews(false);
            }
        }
    }
}
