using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duende : Personaje
{

    public float Vida = 5f;

    public Transform player;                // El jugador a quien el duende perseguirá
    public float distanciaDeteccion = 5f;   // Distancia de detección para perseguir al jugador
    public float velocidadPersecucion = 3.5f; // Velocidad del duende al perseguir
    public float velocidadPatrullaje = 2f;    // Velocidad del duende al patrullar
    public float intervaloMinCambioDireccion = 1f; // Tiempo mínimo para cambiar de dirección
    public float intervaloMaxCambioDireccion = 2f; // Tiempo máximo para cambiar de dirección

    private bool persiguiendo = false;
    private Vector3 direccionPatrullaje;
    private float temporizadorCambioDireccion;

    void Start()
    {
        // Establece una dirección inicial aleatoria al iniciar el juego
        CambiarDireccionPatrullaje();
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        if (distanciaAlJugador <= distanciaDeteccion)
        {
            // Cambia al modo persecución si el jugador está dentro del radio de detección
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
        // Mueve el duende en la dirección actual de patrullaje
        transform.position += direccionPatrullaje * velocidadPatrullaje * Time.deltaTime;

        // Cuenta regresiva para cambiar de dirección
        temporizadorCambioDireccion -= Time.deltaTime;

        // Cambia de dirección al llegar a 0 y reinicia el temporizador con un valor aleatorio
        if (temporizadorCambioDireccion <= 0f)
        {
            CambiarDireccionPatrullaje();
        }
    }

    void CambiarDireccionPatrullaje()
    {
        // Selecciona aleatoriamente una dirección de patrullaje (izquierda o derecha)
        direccionPatrullaje = Random.value > 0.5f ? Vector3.right : Vector3.left;

        // Establece el próximo cambio de dirección en un tiempo aleatorio dentro del rango
        temporizadorCambioDireccion = Random.Range(intervaloMinCambioDireccion, intervaloMaxCambioDireccion);
    }

}
