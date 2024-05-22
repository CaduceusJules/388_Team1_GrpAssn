using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleLamp : MonoBehaviour

{

    public Light spotlight_TOP; // Reference to the spotlight
    public Light pointlight_TOP; // Reference to the point light
    public Light spotlight_BOTTOM; // Reference to the spotlight
    public Light pointlight_BOTTOM; // Reference to the point light

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void LightToggle()
    {
        _audioSource.Play();
        bool lightState = !spotlight_TOP.enabled; // Use the spotlight's current state to determine the new state

        // Toggle both lights
        spotlight_TOP.enabled = lightState;
        pointlight_TOP.enabled = lightState;
        spotlight_BOTTOM.enabled = lightState;
        pointlight_BOTTOM.enabled = lightState;
    }
}

