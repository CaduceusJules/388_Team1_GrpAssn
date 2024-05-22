using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScaleRange : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float baseScale = 1.0f; // Base scale of the reticle at 1 unit distance
    public float scaleFactor = 0.1f; // Scale factor to control how scale changes with distance

    void Update()
    {
        // Calculate the distance from the player to the reticle
        float distance = Vector3.Distance(player.position, transform.position);

        // Calculate the new scale based on the distance
        float newScale = baseScale / (distance * scaleFactor);

        // Apply the new scale to the reticle
        transform.localScale = Vector3.one * newScale;
    }
}
