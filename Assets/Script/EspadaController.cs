using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EspadaController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    AudioSource audioSource;
    public AudioClip clipMuerte;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        EnemyController e = other.collider.GetComponent<EnemyController>();
        EnemyArcherController ea = other.collider.GetComponent<EnemyArcherController>();

        if (e != null)
        {
            Destroy(e.gameObject);
            //audioSource.PlayOneShot(clipMuerte);
        }
        if (ea != null)
        {   Destroy(ea.gameObject);
            audioSource.PlayOneShot(clipMuerte);
        }
        Destroy(gameObject);

        //gameObject.SetActive(false);
        //Destroy(gameObject);
    }

}
