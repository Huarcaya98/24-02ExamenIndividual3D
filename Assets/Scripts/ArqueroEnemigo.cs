using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArqueroEnemigo : MonoBehaviour
{

    public GameObject flechaPrefab;        // Prefab de la flecha
    public Transform puntoDisparo;         // Punto desde donde se disparan las flechas
    public Transform player;               // Referencia al jugador
    public float fuerzaDisparo = 20f;      // Fuerza con la que se lanzan las flechas
    public float intervaloDisparo = 2f;    // Intervalo entre disparos

    private float temporizadorDisparo = 0f;

    void Update()
    {
        temporizadorDisparo += Time.deltaTime;

        if (temporizadorDisparo >= intervaloDisparo)
        {
            DispararFlecha();
            temporizadorDisparo = 0f;
        }
    }

    void DispararFlecha()
    {
        // Calcula la dirección hacia el jugador
        Vector3 direccionHaciaJugador = (player.position - puntoDisparo.position).normalized;

        // Instancia la flecha apuntando en la dirección del jugador
        GameObject flecha = Instantiate(flechaPrefab, puntoDisparo.position, Quaternion.LookRotation(direccionHaciaJugador));

        // Añade fuerza para disparar la flecha hacia el jugador
        Rigidbody rbFlecha = flecha.GetComponent<Rigidbody>();
        rbFlecha.AddForce(direccionHaciaJugador * fuerzaDisparo, ForceMode.Impulse);
    }

}
