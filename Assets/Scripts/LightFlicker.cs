using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public bool canFlicker = false;
    public Light flickeringLight;
    public float minOnTime = 0.2f;
    public float maxOnTime = 1.0f;
    public float minOffTime = 0.1f;
    public float maxOffTime = 0.5f;

    private float nextToggleTime;
    private Color originalColor;
    private bool isLightOn = true;

    public void FlickerLight(bool shouldFlicker,float time)
    {
        if(shouldFlicker) {
            canFlicker = true;
            Invoke("StopFlicker",time);
        }
        else 
        {
            StopFlicker();
        }
    }

    public void ChangeColour()
    {
        flickeringLight.color = Color.red;
        Invoke("ResetColour",12.5f);
    }

    private void ResetColour()
    {
        flickeringLight.color = originalColor;
    }

    private void StopFlicker()
    {
        canFlicker = false;
        flickeringLight.enabled = true;
    }

    void Start()
    {
        if (flickeringLight == null)
        {
            flickeringLight = GetComponent<Light>();
        }
        originalColor = flickeringLight.color;
        flickeringLight.enabled = isLightOn;
        nextToggleTime = Time.time + Random.Range(minOnTime, maxOnTime);
    }

    void Update()
    {
        if(!canFlicker) return;
        if (Time.time >= nextToggleTime)
        {
            isLightOn = !isLightOn;
            flickeringLight.enabled = isLightOn;
            if (isLightOn)
            {
                nextToggleTime = Time.time + Random.Range(minOnTime, maxOnTime);
            }
            else
            {
                nextToggleTime = Time.time + Random.Range(minOffTime, maxOffTime);
            }
        }
    }
}
