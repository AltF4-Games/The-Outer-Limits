using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Pilot : MonoBehaviour
{
    public Transform pilotCameraRoot;
    public Transform playerCameraRoot;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public SpaceshipMovement movement;
    public StarterAssets.FirstPersonController controller;
    public KeyCode key = KeyCode.Escape;
    private bool inSeat = false;

    public void SwitchViews(bool val)
    {
        if(val) {
            cinemachineVirtualCamera.Follow = pilotCameraRoot;
            inSeat = true;
            movement.enabled = true;
            controller.enabled = false;
        } 
        else {
            controller.enabled = true;
            cinemachineVirtualCamera.Follow = playerCameraRoot;
            inSeat = false;
            movement.enabled = false;
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
