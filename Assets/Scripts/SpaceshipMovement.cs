using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 10.0f; // Adjust this to set the speed of the spaceship
    public float rotationSpeed = 3.0f; // Adjust this to set the rotation speed
    public CameraShake shake;
    public ParticleSystem particleSystem;
    private Vector3 previousPosition;

    public float damping = 0.9f; // Adjust this to set the damping factor (0.0f - 1.0f)
    private float currentRotationSpeed = 0.0f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        // Initialize the previous position
        previousPosition = transform.position;
    }

    void Update()
    {
        // Get input for movement
        float verticalInput = Input.GetAxis("Vertical");     // W/S keys or Up/Down arrow keys
        // Calculate movement
        Vector3 movement = new Vector3(-verticalInput, 0, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;

        // Get input for rotation
        float rotationInput = Input.GetAxis("Horizontal"); // A/D keys or Left/Right arrow keys

        // Calculate rotation speed based on input
        currentRotationSpeed = rotationInput * rotationSpeed;

        // Apply rotation
        transform.Rotate(Vector3.up, currentRotationSpeed * Time.deltaTime);

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
        
        // Apply damping to velocity
        movement *= damping;
        // Apply damping to rotation speed
        currentRotationSpeed *= damping;
    }
}
