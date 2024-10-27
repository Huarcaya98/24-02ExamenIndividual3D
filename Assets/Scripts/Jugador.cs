using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jugador : Personaje
{
    [SerializeField] float Vida = 100f;
    public float MaxVida = 100f;
    [SerializeField] float Mana = 100f;
    public float MaxMana = 100f;
    public float ContadorObjetos = 0f;

    //Caminar
    protected override void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Movemos al jugador según la velocidad y las direcciones
        Vector3 movimiento = transform.forward * vertical + transform.right * horizontal;
        movimiento.Normalize();// Normalizamos para evitar mayor velocidad en diagonales
        rb.velocity = new Vector3(movimiento.x * velocidad, rb.velocity.y, movimiento.z * velocidad);
    }

    //Correr
    protected override void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift) && EstaEnSuelo())
        {
            velocidad = 7.5f;
        }
        else
        {
            velocidad = 5f;
        }
    }

    //Saltar
    protected override void Saltar()
    {
        if (Input.GetButtonDown("Jump") && EstaEnSuelo())
        {
            rb.AddForce(new Vector3(0, FuerzaSalto, 0), ForceMode.Impulse);
        }
    }

    //Agacharse
    protected override void Agacharse()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.7f, transform.localScale.y);
            agachado = true;
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.y);
            agachado = false;
        }
    }

    //Objeto
    protected override void Objeto(int value)
    {
        ContadorObjetos += value;
    }

    //Vida 
    protected override void CambioVida(int value)
    {
        Vida += value;
        if (Vida > MaxVida)
        {
            Vida = MaxVida;
        }
        if (Vida <= 0)
        {
            Destroy(gameObject);
            //Cambio D escena Muerto
        }
    }
    //Mana
    protected override void CambioMana(int value)
    {
        Mana += MaxMana;

        if (Mana > 100)
        {
            Mana = MaxMana;
        }
        if (Mana >= 0)
        {
            Mana = 0;
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemigos"))
    //    {
    //        CambioVida(-5);
    //    }
    //}

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}
