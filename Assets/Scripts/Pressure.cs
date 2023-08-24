using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pressure : MonoBehaviour
{
    private float rotationSpeed = 180f;
    public float m_Pressure = 14.696f;
    public AudioClip squeak;
    public TextMeshProUGUI pressureText;
    private bool isRotating = false;
    public bool canDecreaseCount = false;

    private void Start()
    {
        StartCoroutine(IncreasePressure());
    }

    public void RotateValve()
    {
        StartCoroutine(Rotate360Degrees());
        AudioManager.instance.PlayAudio(squeak,1f);
        canDecreaseCount = false;
        m_Pressure = 14.696f;
        pressureText.text = "Pressure Inside : " + m_Pressure + " psi"; 
    }

    private IEnumerator IncreasePressure()
    {
        yield return new WaitForSeconds(.5f);
        if(!canDecreaseCount) {
            StartCoroutine(IncreasePressure());
            yield break;
        }
        yield return new WaitForSeconds(1.5f);
        m_Pressure-=0.4f;
        if(m_Pressure <= 1.2f) {
            EndingManager.instance.DeathDueToSuffocation("YOU DIED\n DUE TO A EXPLOSION CAUSED BY LOW PRESSURE");
            Debug.Log("Lmao Ded, by too low pressure");
        }
        pressureText.text = "Pressure Inside : " + m_Pressure + " psi";
        StartCoroutine(IncreasePressure());
    }

    private IEnumerator Rotate360Degrees()
    {
        if(isRotating) yield break;
        isRotating = true;

        float startRotation = transform.rotation.eulerAngles.z;
        float endRotation = startRotation + 360f;

        float elapsedTime = 0f;

        while (elapsedTime < 2f)
        {
            float rotationAmount = Mathf.Lerp(startRotation, endRotation, elapsedTime / 2f);
            transform.rotation = Quaternion.Euler(0f, -180f, rotationAmount);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        //transform.rotation = Quaternion.Euler(0f, -180f, endRotation);
        isRotating = false;
    }
}
