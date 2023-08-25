using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ending_No_IFF : MonoBehaviour
{
public TextMeshProUGUI subText;
    public AudioClip scareClip;
    public GameObject reaper;
    public GameObject blackImage;
    public AudioClip scanClip;

    private void Start()
    {
        StartCoroutine(Ending());
    }

    private IEnumerator Ending()
    {
        yield return new WaitForSeconds(4f);
        subText.text = "[Mothership] : -ufid---?chk(id--of-spcship-=for-iff)";
        yield return new WaitForSeconds(8f);
        subText.text = "[Mothership] : *SCANNING*";
        yield return new WaitForSeconds(3f);
        subText.text = "";
        AudioManager.instance.PlayAudio(scanClip,1.0f);
        yield return new WaitForSeconds(30f);//JUMPSCARE
        blackImage.SetActive(true);
        yield return new WaitForSeconds(.25f);//JUMPSCARE
        blackImage.SetActive(false);
        reaper.SetActive(true);
        AudioManager.instance.PlayAudio(scareClip,1.0f);
        yield return new WaitForSeconds(1f);
        blackImage.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
}
