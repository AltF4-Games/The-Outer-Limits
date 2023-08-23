using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProximitySensor : MonoBehaviour
{
    public TextMeshProUGUI uiText; // Reference to the UI Text element.
    public Transform ship; // Reference to the player's transform.
    public float detectionRadius = 25f; // The radius within which proximity is detected.

    private void Update()
    {
        // Find all colliders within the detection radius.
        Collider[] colliders = Physics.OverlapSphere(ship.position, detectionRadius);

        // Create a dictionary to store the detected objects and their positions.
        Dictionary<string, Vector3> detectedObjects = new Dictionary<string, Vector3>();

        // Loop through the detected colliders.
        foreach (Collider collider in colliders)
        {
            // Check if the collider has a GameObject attached to it.
            GameObject obj = collider.gameObject;

            // Check if the detected object is not the player.
            if (obj != ship.gameObject && !obj.transform.IsChildOf(ship))
            {
                // Calculate the position relative to the player.
                Vector3 relativePosition = obj.transform.position - ship.position;

                // Add the detected object and its relative position to the dictionary.
                detectedObjects[obj.name] = relativePosition;
            }
        }

        // Update the UI Text with the detected objects and their relative positions.
        UpdateUIText(detectedObjects);
    }

    private void UpdateUIText(Dictionary<string, Vector3> objects)
    {
        // Clear the UI Text.
        uiText.text = "";

        // Iterate through the detected objects and add their names and positions to the UI Text.
        foreach (var kvp in objects)
        {
            uiText.text += $"{kvp.Key}: {kvp.Value}\n";
        }
    }
}
