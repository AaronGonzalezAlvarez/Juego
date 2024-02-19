using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgujeroController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public AudioClip clip;
    AudioSource audioSource;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            audioSource.PlayOneShot(clip);
        }
        
    }

    

}
