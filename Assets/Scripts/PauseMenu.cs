using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    [SerializeField] private GameObject pauseMenuPrefab;
    [SerializeField] private UnityEngine.InputSystem.PlayerInput input_;
    GameObject currentPauseMenu;
    bool doOnce = false;
    [HideInInspector] public bool Ispaused;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Ispaused = !Ispaused;
        }
        HandlePauseUnpause();
    }

    private void HandlePauseUnpause()
    {
        if (Ispaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            input_.enabled = false;
            if (currentPauseMenu == null)
                currentPauseMenu = Instantiate(pauseMenuPrefab, Vector3.zero, Quaternion.identity);
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            input_.enabled = true;
            Time.timeScale = 1f;
            if (currentPauseMenu != null)
                Destroy(currentPauseMenu);
        }
    }
}
