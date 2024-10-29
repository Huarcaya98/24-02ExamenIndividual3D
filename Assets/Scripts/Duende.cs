using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duende : Personaje
{

    public float Vida = 5f;


    public Transform player;           // El jugador a quien el duende perseguir�
    public float distanciaDeteccion = 5f; // Distancia de detecci�n para perseguir al jugador
    public float velocidadPersecucion = 3.5f; // Velocidad del duende al perseguir
    public float velocidadPatrullaje = 2f; // Velocidad del duende al patrullar
    public float intervaloCambioDireccion = 2f; // Tiempo en segundos para cambiar de direcci�n

    private bool persiguiendo = false;
    private Vector3 direccionPatrullaje;

    void Start()
    {
        // Comienza patrullando en una direcci�n
        direccionPatrullaje = Vector3.right; // Inicialmente a la derecha
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        if (distanciaAlJugador <= distanciaDeteccion)
        {
            // Cambia al modo persecuci�n si el jugador est� dentro del radio de detecci�n
            persiguiendo = true;
        }
        else
        {
            // Vuelve al modo patrullaje si el jugador se sale del radio
            persiguiendo = false;
        }

        if (persiguiendo)
        {
            PerseguirJugador();
        }
        else
        {
            Patrullar();
        }
    }

    void PerseguirJugador()
    {
        // Moverse hacia el jugador
        transform.position = Vector3.MoveTowards(transform.position, player.position, velocidadPersecucion * Time.deltaTime);
        // Girar hacia el jugador
        transform.LookAt(player);
    }

    void Patrullar()
    {
        // Cambia la direcci�n de patrullaje cada intervalo de tiempo
        float tiempoPingPong = Mathf.PingPong(Time.time / intervaloCambioDireccion, 1);
        direccionPatrullaje = tiempoPingPong > 0.5f ? Vector3.right : Vector3.left;

        // Mueve el duende en la direcci�n actual de patrullaje
        transform.position += direccionPatrullaje * velocidadPatrullaje * Time.deltaTime;
    }

}
