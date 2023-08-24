using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public static EndingManager instance;
    public AudioClip explosionSoundFX;
    public AudioClip coughFX;
    public GameObject blackScreen;
    public TextMeshProUGUI endingText;

    private void Awake()
    {
        instance = this;
    }

    public void ExplosionEnding(string deathMessage)
    {
        StartCoroutine(explodeEnding(deathMessage));
    }

    private IEnumerator explodeEnding(string deathMessage)
    {
        AudioManager.instance.PlayAudio(explosionSoundFX,1.0f);
        yield return new WaitForSeconds(.3f);
        blackScreen.SetActive(true);
        endingText.text = deathMessage;
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DeathDueToSuffocation(string deathMessage)
    {
        StartCoroutine(suffocationEnding(deathMessage));
    }

    private IEnumerator suffocationEnding(string deathMessage)
    {
        AudioManager.instance.PlayAudio(coughFX,1.0f);
        yield return new WaitForSeconds(.3f);
        blackScreen.SetActive(true);
        endingText.text = deathMessage;
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Crashed(string deathMessage)
    {
        StartCoroutine(CrashedEnum(deathMessage));
    }

    private IEnumerator CrashedEnum(string deathMessage)
    {
        AudioManager.instance.PlayAudio(explosionSoundFX,1.0f);
        yield return new WaitForSeconds(.3f);
        blackScreen.SetActive(true);
        endingText.text = deathMessage;
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
