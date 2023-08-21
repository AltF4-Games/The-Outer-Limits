using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private bool shakeTimer;
    private float shakeIntensity;

    public void ShakeCamera(float intensity,bool toggle)
    {
        shakeIntensity = intensity;
        shakeTimer = toggle;
    }

    void LateUpdate()
    {
        if (shakeTimer)
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeIntensity;
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 1.0f; // Adjust frequency as needed
        }
        else
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
        }
    }
}
