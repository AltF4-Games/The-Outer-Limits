using UnityEngine;
using TMPro;

public class AntiGravity : MonoBehaviour
{
    // Artificial Gravity Generators
    public StarterAssets.FirstPersonController player;
    public TextMeshProUGUI antiGravText;
    public AudioClip buttonPress;
    private bool isGravFlipped = false;

    public void ToggleGravity()
    {
        isGravFlipped = !isGravFlipped;
        AudioManager.instance.PlayAudio(buttonPress,1.0f);
        if(isGravFlipped) TurnOffGravity();
        else TurnOnGravity();
    }

    public void TurnOffGravity()
    {
        player.Gravity = -player.Gravity;
        antiGravText.text = "Gravity Generators: \nDisengaged";
        isGravFlipped = true;
    }

    public void TurnOnGravity()
    {
        player.Gravity = -player.Gravity;
        antiGravText.text = "Gravity Generators: \nEngaged";
        isGravFlipped = false;
    }

}
