using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    // Artificial Gravity Generators
    public StarterAssets.FirstPersonController player;
    private bool isGravFlipped = false;

    public void TurnOffGravity()
    {
        player.Gravity = -player.Gravity;
        isGravFlipped = true;
    }

    public void TurnOnGravity()
    {
        player.Gravity = -player.Gravity;
        isGravFlipped = false;
    }

}
