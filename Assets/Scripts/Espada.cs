using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : Arma
{

    public float duracionAtaque = 0.2f;  // Duración del ataque
    public float anguloAtaque = 45f;     // Ángulo de rotación para el ataque
    public float desplazamientoAtaque = 0.2f; // Distancia de avance de la espada en el ataque

    private bool atacando = false;
    private float tiempoAtaque = 0f;
    private Vector3 posicionOriginal;
    private Quaternion rotacionOriginal;

    void Start()
    {
        // Guardamos la posición y rotación originales
        posicionOriginal = transform.localPosition;
        rotacionOriginal = transform.localRotation;
    }

    void Update()
    {
        AliniearArma();

        if (Input.GetMouseButtonDown(0) && !atacando)
        {
            // Iniciar el ataque
            atacando = true;
            tiempoAtaque = 0f;
        }

        if (atacando)
        {
            RealizarAtaque();
        }
    }

    protected override void AliniearArma()
    {
        // Alinear la espada con la cámara
        transform.position = camara.position + camara.TransformDirection(offset);

        // Rotar la espada suavemente según la rotación de la cámara
        transform.rotation = Quaternion.Lerp(transform.rotation, camara.rotation, Time.deltaTime * 10f);
    }

    private void RealizarAtaque()
    {
        // Calcula el progreso del ataque
        tiempoAtaque += Time.deltaTime;
        float progreso = tiempoAtaque / duracionAtaque;

        // Interpola la rotación y posición para simular el ataque
        transform.localRotation = Quaternion.Lerp(rotacionOriginal, rotacionOriginal * Quaternion.Euler(-anguloAtaque, 0, 0), progreso);
        transform.localPosition = Vector3.Lerp(posicionOriginal, posicionOriginal + transform.forward * desplazamientoAtaque, progreso);

        // Finaliza el ataque cuando el progreso alcanza el 100%
        if (progreso >= 1f)
        {
            transform.localRotation = rotacionOriginal;
            transform.localPosition = posicionOriginal;
            atacando = false;
        }
    }

}
