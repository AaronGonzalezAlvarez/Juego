using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuntuacionGemas : MonoBehaviour
{

    private float puntos;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        //puntos += Time.deltaTime;
        //text.text = puntos.ToString("0");
    }

    public void sumarGema()
    {
        puntos ++;
        text.text = puntos.ToString("0");
    }

}
