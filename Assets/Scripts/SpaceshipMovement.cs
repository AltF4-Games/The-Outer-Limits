using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 3.0f;
    public CameraShake shake;
    public ParticleSystem particleSystem;
    private Vector3 previousPosition;

    public float damping = 0.9f; // Adjust this to set the damping factor (0.0f - 1.0f)
    private float currentRotationSpeed = 0.0f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-verticalInput, 0, 0) * speed * Time.deltaTime;
        transform.Translate(movement);
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;

        float rotationInput = Input.GetAxis("Horizontal");

        currentRotationSpeed = rotationInput * rotationSpeed;

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
        
        movement *= damping;
        currentRotationSpeed *= damping;
    }
}
