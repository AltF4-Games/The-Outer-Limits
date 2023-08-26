using UnityEngine;
using TMPro;

public class Voice_AA_01 : MonoBehaviour
{
    public string subTitle = "As you approach the mass relay, please be aware that it constitutes a point of no return. According to our scientists, the mass relay operates exclusively in a one-way manner.";
    public AudioClip voiceClip;
    public TextMeshProUGUI subText;

    void Start()
    {
        Invoke("PlayClip",1.5f);
    }

    private void PlayClip()
    {
        subText.text = subTitle;
        AudioManager.instance.PlayAudio(voiceClip,1.0f);
        Invoke("ClearSub",15f);
    }

    private void ClearSub()
    {
        subText.text = "";
    }
}
