using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 30.0f;
    public float autoPilotSpeed = 10.0f;
    public float rotationSpeed = 3.0f;
    public float damping = 0.9f; // Adjust this to set the damping factor (0.0f - 1.0f)
    public CameraShake shake;
    public ParticleSystem particleSystem;
    public TextMeshProUGUI coordText;
    private KeyCode autoPilotKey = KeyCode.CapsLock;
    public Transform player;

    private Vector3 previousPosition;
    private float currentRotationSpeed = 0.0f;
    private Vector3 velocity = Vector3.zero;
    private bool autoPilotOn = false;
    [HideInInspector] public bool canDrive = false;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        float verticalInput = 0;
        float rotationInput = 0;
        if(canDrive) {
            verticalInput = Input.GetAxis("Vertical");
        }


        Vector3 movement = new Vector3(-verticalInput, 0, 0) * speed * Time.deltaTime;

        if(autoPilotOn) {
            movement = new Vector3(-1, 0, 0) * autoPilotSpeed * Time.deltaTime;
            //player.GetComponent<CharacterController>().Move(movement);
        }

        transform.Translate(movement);
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        
        if(canDrive) {
            rotationInput = Input.GetAxis("Horizontal");
        }

        currentRotationSpeed = rotationInput * rotationSpeed;

        transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);
        UpdateCoordsText();

        if(velocity.magnitude > 1)
        {
            shake.ShakeCamera(0.7f,true);
            if(!particleSystem.isPlaying)
                particleSystem.Play();
        }
        else
        {
            shake.ShakeCamera(2f,false);
            particleSystem.Stop();
        }

        if(Input.GetKeyDown(autoPilotKey))
        {
            autoPilotOn = !autoPilotOn;
        }
        
        movement *= damping;
        currentRotationSpeed *= damping;
    }

    private void UpdateCoordsText()
    {
        coordText.text = "X:" + Math.Round(transform.position.x) + "\nY:" + Math.Round(transform.position.z) + "\nA:" + Math.Round(transform.rotation.eulerAngles.x);   
    }
}
