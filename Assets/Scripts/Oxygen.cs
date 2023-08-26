using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oxygen : MonoBehaviour
{
    public int m_Oxygen = 100;
    public Image oxygen_bar;
    public AudioClip wheeze;
    public AudioClip buttonPress;
    public AudioClip warning;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI warningText;
    public bool canDecreaseCount = false;
    private bool wheezed = false;

    private void Start()
    {
        StartCoroutine(OxygenCount());
    }

    public void ToggleOxygen()
    {
        canDecreaseCount = !canDecreaseCount;
        AudioManager.instance.PlayAudio(buttonPress,1.0f);
    }

    private IEnumerator OxygenCount()
    {
        yield return new WaitForSeconds(.5f);
        oxygenText.text = "OXYGEN: " + m_Oxygen + "%";
        if(!canDecreaseCount) {
            m_Oxygen = Mathf.Clamp(m_Oxygen+1,0,100);
            oxygen_bar.fillAmount = m_Oxygen/100f;
            StartCoroutine(OxygenCount());
            yield break;
        }
        yield return new WaitForSeconds(1.5f);
        m_Oxygen--;
        if(m_Oxygen <= 8) {
            EndingManager.instance.DeathDueToSuffocation("YOU DIED\n DUE TO LOW OXYGEN");
            Debug.Log("Lmao Ded, due to low oxygen");
        }   
        if(m_Oxygen <= 25) {
            if(wheezed == false) {
                AudioManager.instance.PlayAudio(warning,1.0f);
                warningText.text = "[WARNING] : OXYGEN TOO LOW!";
                Invoke("ClearText",10f);
                wheezed = true;
            }
        }
        else
        {
            wheezed = false;
        }
        oxygen_bar.fillAmount = m_Oxygen/100f;
        StartCoroutine(OxygenCount());
    }

    private void ClearText()
    {
        warningText.text = "";
        wheezed = false;
    }
}
