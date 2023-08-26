using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

[RequireComponent (typeof (Interactable))]
public class Pilot : MonoBehaviour
{
    public Transform pilotCameraRoot;
    public Transform playerCameraRoot;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public SpaceshipMovement movement;
    public StarterAssets.FirstPersonController controller;
    public Interact interact;
    public GameObject itemDescription;
    public TextMeshProUGUI subText;
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
            itemDescription.SetActive(false);
        } 
        else {
            if(movement.autoPilotOn == true){
                StartCoroutine(AutoPilotHelp());
                return;
            }

            controller.enabled = true;
            cinemachineVirtualCamera.Follow = playerCameraRoot;
            inSeat = false;
            movement.canDrive = false;
            interact.enabled = true;
            itemDescription.SetActive(true);
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

    private IEnumerator AutoPilotHelp()
    {
        subText.text = "You can't leave your seat while Auto Pilot is ON!";
        yield return new WaitForSeconds(3f);
        subText.text = "";
    }
}
