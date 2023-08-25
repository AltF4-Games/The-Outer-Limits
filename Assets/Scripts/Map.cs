using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Map : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public AudioClip pickUp;

    public void SetObjective()
    {
        objectiveText.text += "\nX:-8940 Y:-4100";
        AudioManager.instance.PlayAudio(pickUp,1.0f);
        Destroy(gameObject);
    }
}
