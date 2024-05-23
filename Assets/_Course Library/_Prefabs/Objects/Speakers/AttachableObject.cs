using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachableObject : MonoBehaviour
{
    public Transform socket; // The socket to attach to
    public float rotationSpeed = 100f; // Rotation speed
    private bool isAttached = false; // Track attachment state
    public float positionTolerance = 0.01f;
    private AudioSource audioSource; // Reference to the AudioSource
    private XRGrabInteractable grabInteractable; // Reference to the XRGrabInteractable component

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Add event listeners for attachment and detachment
        grabInteractable.selectEntered.AddListener(OnSelectEnter);
        grabInteractable.selectExited.AddListener(OnSelectExit);
    }

    // Event listener for attachment
    private void OnSelectEnter(SelectEnterEventArgs args)
    {
            Attach();
    }

    // Event listener for detachment
    private void OnSelectExit(SelectExitEventArgs args)
    {
            Detach();
    }
    
    // Method to attach the object to the socket
    public void Attach()
    {
        isAttached = true;
    }

    // Method to detach the object from the socket
    public void Detach()
    {
        isAttached = false;
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    private bool IsAttachedToSocket
    {
        get
        {
            // Check if the object is attached and within the position tolerance of the socket
            return isAttached && Vector3.Distance(transform.position, socket.position) <= positionTolerance;
        }
    }

    void Update()
    {
        if (IsAttachedToSocket)
        {
            // Rotate the object
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

            // Ensure the music is playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Stop the music if not attached or not slotted onto the socket
            if (audioSource.isPlaying)
            {
                audioSource.Stop();            }
        }
    }
}
