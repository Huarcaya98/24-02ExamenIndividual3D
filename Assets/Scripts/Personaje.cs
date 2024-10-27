using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float FuerzaSalto = 5f;
    public bool agachado;
    
    protected Rigidbody rb;
    public bool enSuelo;

    private void Awake()
    {
        Init();
    }
    
    protected virtual void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Movimiento();
        Saltar();
        Correr();
        Agacharse();
        
    }

    protected virtual void Movimiento()
    {

    }

    protected virtual void Saltar()
    {

    }

    protected virtual void Correr()
    {

    }

    protected virtual void Agacharse()
    {

    }

    protected virtual void Objeto(int value)
    {

    }

    protected virtual void CambioVida(int value)
    {

    }

    protected virtual void CambioMana(int value)
    {

    }

    protected virtual void CambioEnergia(int value)
    {

    }

    protected virtual bool EstaEnSuelo()
    {
        return enSuelo;
    }

    protected virtual bool EstaEnAire()
    {
        return !EstaEnSuelo();
    }



}
