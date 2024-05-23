using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class FanControl : MonoBehaviour
{
    public GameObject fan; // The fan object to control
    public float maxSpeed = 1000f; // The maximum speed of the fan
    public float acceleration = 100f; // How fast the fan speeds up
    public float deceleration = 100f; // How fast the fan slows down

    private bool state = false;
    private bool isFanOn = false; // Track the fan state
    private float currentSpeed = 0f; // Current speed of the fan
    private Coroutine fanCoroutine; // To control the speed change over time

    private void Update()
    {
        if (isFanOn && currentSpeed > 0)
        {
            fan.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
        }
        else if (!isFanOn && currentSpeed > 0)
        {
            fan.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        // Register for the poke interaction events
        GetComponent<XRSimpleInteractable>().firstHoverEntered.AddListener(OnPokeStart);
        //GetComponent<XRSimpleInteractable>().lastHoverExited.AddListener(OnPokeEnd);
    }

    private void OnDisable()
    {
        // Unregister the poke interaction events
        GetComponent<XRSimpleInteractable>().firstHoverEntered.RemoveListener(OnPokeStart);
        //GetComponent<XRSimpleInteractable>().lastHoverExited.RemoveListener(OnPokeEnd);
    }

    private void OnPokeStart(HoverEnterEventArgs args)
    {
        if (!state)
        {
            ToggleFan(true);
            state = true;
        }
        else
        {
             if (state)
            {
                ToggleFan(false);
                state = false;
            }
        }
    }
    /*
    private void OnPokeEnd(HoverExitEventArgs args)
    {
        ToggleFan(false);
    }
    */

    private void ToggleFan(bool state)
    {
        if (isFanOn != state)
        {
            isFanOn = state;

            if (fanCoroutine != null)
            {
                StopCoroutine(fanCoroutine);
            }

            fanCoroutine = StartCoroutine(ChangeFanSpeed(state));
        }
    }

    private IEnumerator ChangeFanSpeed(bool turnOn)
    {
        while ((turnOn && currentSpeed < maxSpeed) || (!turnOn && currentSpeed > 0))
        {
            currentSpeed = Mathf.Clamp(currentSpeed + (turnOn ? acceleration : -deceleration) * Time.deltaTime, 0, maxSpeed);
            fan.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
            yield return null;
        }

        if (!turnOn)
        {
            currentSpeed = 0;
        }
    }
}
