using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioArma : MonoBehaviour
{

    public GameObject espada;
    public GameObject baculo;
    private int armaSeleccionada = 0;  // Por defecto inicia con la escopeta

    void Start()
    {
        SeleccionarArma();
    }

    void Update()
    {
        // Cambiar de arma con las teclas 1 y 2
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            armaSeleccionada = 0;  // espada
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            armaSeleccionada = 1;  // baculo
        }

        // Cambiar de arma con la rueda del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            armaSeleccionada = (armaSeleccionada + 1) % 2;  // Cambia hacia arriba
        }
        else if (scroll < 0f)
        {
            armaSeleccionada = (armaSeleccionada - 1 + 2) % 2;  // Cambia hacia abajo
        }

        SeleccionarArma();
    }

    void SeleccionarArma()
    {
        // Activa la arma seleccionada y desactiva la otra
        espada.SetActive(armaSeleccionada == 0);
        baculo.SetActive(armaSeleccionada == 1);
    }

    public bool EsBaculoActiva()
    {
        return armaSeleccionada == 1;
    }

}
