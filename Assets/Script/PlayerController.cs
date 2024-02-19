using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.WSA;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float velocidad = 6.0f;
    Animator animator;
    Vector2 lookDirection = new Vector2(0, -1);
    int numJoyas;
    bool isRecogido = false;
    public GameObject espadaPrefab;
    AudioSource audioSource;
    public AudioClip clipJoya;
    public AudioClip clipEspada;
    public AudioClip clipTP;
    public AudioClip clipHierba;
    public AudioClip clipPasos;

    float horizontal;
    float vertical;

    //pruebas
    //public InputAction talkAction;

    //puntuacion
    public PuntuacionGemas puntuacionGemas;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        numJoyas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        // HA RECOGIDO EL ARMA
        if (isRecogido && Input.GetKeyDown(KeyCode.E))
        {
            Lanzar();
        }
    }

    private void FixedUpdate()
    {
        
        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        Vector2 position = rigidbody2d.position;
        position = position + move * velocidad * Time.deltaTime;

        animator.SetFloat("moveX", lookDirection.x);
        animator.SetFloat("moveY", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        rigidbody2d.MovePosition(position);
    
        // TODO poner if joyas
        // SACARLO DEL FIXEDUPDATE
        if(numJoyas == 4)
        {
            Debug.Log("FIN DE PARTIDA");
        }

        

    }

    private void Lanzar()
    {
        // Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        GameObject espada = Instantiate(espadaPrefab, rigidbody2d.position + Vector2.up * -0.1f, Quaternion.identity);
        EspadaController lanzarEspada = espada.GetComponent<EspadaController>();
        lanzarEspada.Launch(lookDirection, 300);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("agujero"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("hierba")){
            audioSource.PlayOneShot(clipHierba);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("espada"))
        {
            audioSource.PlayOneShot(clipEspada);
            Destroy(collision.gameObject);
            Debug.Log("Ha cogido la espada");
            isRecogido = true;

        }
        if (collision.CompareTag("joyas"))
        {
            audioSource.PlayOneShot(clipJoya);
            Destroy(collision.gameObject);
            Debug.Log("Ha recogido una joya!");
            numJoyas++;
            puntuacionGemas.sumarGema();
        }
        if (collision.CompareTag("teletransportar"))
        {
            audioSource.PlayOneShot(clipTP);
            Vector3 coordenadas = new Vector3(67.53f, -1,0);
            this.transform.position = coordenadas;
        }
        if (collision.CompareTag("volver"))
        {
            audioSource.PlayOneShot(clipTP);
            Vector3 coordenadas = new Vector3(11.1f, 8.95f, 0);
            this.transform.position = coordenadas;
        }
    }


    public int getNumJoyas () { 
        return numJoyas; 
    }

   
}
