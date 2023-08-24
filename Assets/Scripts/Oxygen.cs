using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class Oxygen : MonoBehaviour
{
    public int m_Oxygen = 100;
    public Image oxygen_bar;
    public PostProcessProfile profile;
    public AudioClip wheeze;
    public AudioClip buttonPress;
    public TextMeshProUGUI oxygenText;
    public bool canDecreaseCount = false;
    private Vignette vignette;
    private bool wheezed = false;

    private void Start()
    {
        StartCoroutine(OxygenCount());
        if (vignette != null)
        {
            vignette.intensity.value = 0.44f;
        }
        profile.TryGetSettings(out vignette);
    }

    public void ToggleOxygen()
    {
        canDecreaseCount = !canDecreaseCount;
        AudioManager.instance.PlayAudio(buttonPress,1.0f);
    }

    private IEnumerator OxygenCount()
    {
        yield return new WaitForSeconds(.5f);
        if(!canDecreaseCount) {
            StartCoroutine(OxygenCount());
            yield break;
        }
        yield return new WaitForSeconds(1f);
        m_Oxygen--;
        oxygenText.text = "OXYGEN: " + m_Oxygen + "%";
        if(m_Oxygen <= 12) {
            EndingManager.instance.DeathDueToSuffocation("YOU DIED\n DUE TO LOW OXYGEN");
            Debug.Log("Lmao Ded, due to low oxygen");
        }   
        if(m_Oxygen <= 25) {
            if (vignette != null)
            {
                vignette.intensity.value = 0.75f;
            }
            if(wheezed == false) {
                AudioManager.instance.PlayAudio(wheeze,1.0f);
                wheezed = true;
            }
        }
        oxygen_bar.fillAmount = m_Oxygen/100f;
        StartCoroutine(OxygenCount());
    }
}
