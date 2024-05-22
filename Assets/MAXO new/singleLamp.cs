using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleLamp : MonoBehaviour
{

    public Light spotlight; // Reference to the spotlight
    public Light pointlight; // Reference to the point light


    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void LightToggle()
    {
        _audioSource.Play();
        bool lightState = !spotlight.enabled; // Use the spotlight's current state to determine the new state

        // Toggle both lights
        spotlight.enabled = lightState;
        pointlight.enabled = lightState;

    }
}
