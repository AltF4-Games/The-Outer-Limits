using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pressure : MonoBehaviour
{
    public float m_Pressure = 14.696f;
    public AudioClip squeak;
    public AudioClip warning;
    public Animation animation;
    public TextMeshProUGUI pressureText;
    public TextMeshProUGUI warningText;
    private bool isRotating = false;
    public bool canDecreaseCount = false;
    private bool warned = false;

    private void Start()
    {
        StartCoroutine(IncreasePressure());
    }

    public void RotateValve()
    {
        animation.Play();
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
        yield return new WaitForSeconds(2.5f);
        m_Pressure-=0.4f;
        if(m_Pressure <= 3.0f) {
            if(warned == false) {
                AudioManager.instance.PlayAudio(warning,1.0f);
                warningText.text = "[WARNING] : PRESSURE TOO LOW!";
                Invoke("ClearText",10f);
                warned = true;
            }
        }

        if(m_Pressure <= 1.2f) {
            EndingManager.instance.DeathDueToSuffocation("YOU DIED\n DUE TO A EXPLOSION CAUSED BY LOW PRESSURE");
            Debug.Log("Lmao Ded, by too low pressure");
        }
        pressureText.text = "Pressure Inside : " + m_Pressure + " psi";
        StartCoroutine(IncreasePressure());
    }

    private void ClearText()
    {
        warningText.text = "";
        warned = false;
    }
}
