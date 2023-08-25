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
    public AudioClip teleport;
    public ParticleSystem explosionFx;
    public GameObject blackScreen;
    public TextMeshProUGUI endingText;
    public bool doesHaveIFF = false;

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
        explosionFx.gameObject.SetActive(true);
        explosionFx.Play();
        AudioManager.instance.PlayAudio(explosionSoundFX,1.0f);
        yield return new WaitForSeconds(.5f);
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
        yield return new WaitForSeconds(.01f);
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
        explosionFx.gameObject.SetActive(true);
        explosionFx.Play();
        AudioManager.instance.PlayAudio(explosionSoundFX,1.0f);
        yield return new WaitForSeconds(.5f);
        blackScreen.SetActive(true);
        endingText.text = deathMessage;
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinalEnding()
    {
        if(doesHaveIFF == true)
        {
            blackScreen.SetActive(true);
            AudioManager.instance.PlayAudio(teleport,1.0f);
            Invoke("LoadIFFEnding",3f);
        }
        else
        {
            blackScreen.SetActive(true);
            AudioManager.instance.PlayAudio(teleport,1.0f);
            Invoke("LoadNoIFFEnding",3f);
        }
    }

    private void LoadIFFEnding()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    private void LoadNoIFFEnding()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
