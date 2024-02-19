using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManejoCanvasController : MonoBehaviour
{

    public PlayerController playerController;
    public GameObject canvas;
    public GameObject mensajeGana;
    public GameObject mensajePirtde;
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController == null)
        {
            canvas.gameObject.SetActive(true);
            mensajePirtde.gameObject.SetActive(true);
            mensajeGana.gameObject.SetActive(false);
            Time.timeScale = 0;
        }

        if (playerController.getNumJoyas() == 4)
        {
            canvas.gameObject.SetActive(true);
            mensajePirtde.gameObject.SetActive(false);
            mensajeGana.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}