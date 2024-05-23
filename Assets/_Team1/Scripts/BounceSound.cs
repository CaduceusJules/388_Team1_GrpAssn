using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSound : MonoBehaviour
{
    public AudioSource bounceAudio;
    // Start is called before the first frame update
    void Start()
    {
        bounceAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounceAudio.Play();
    }
}
