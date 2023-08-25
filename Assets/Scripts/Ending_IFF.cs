using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ending_IFF : MonoBehaviour
{
    public GameObject subText;
    public GameObject blackImage;
    public SpaceshipMovement spaceshipMovement;

    private void Start()
    {
        spaceshipMovement.canDrive = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnTriggerEnter(Collider other)
    {
        blackImage.SetActive(true);
        subText.SetActive(true);
        Invoke("LoadToMenu",10f);
    }

    private void LoadToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
