using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Pilot : MonoBehaviour
{
    public Transform pilotCameraRoot;
    public Transform playerCameraRoot;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public CameraShake shake;
    public ParticleSystem particleSystem;

    public void SwitchViews(bool val)
    {
        if(val) {
            cinemachineVirtualCamera.Follow = pilotCameraRoot;
            shake.ShakeCamera(3f,true);
            particleSystem.Play();
        } 
        else {
            cinemachineVirtualCamera.Follow = playerCameraRoot;
            shake.ShakeCamera(0,false);
            particleSystem.Stop();
        }

    }
}
