using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasEnergia : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody rb;
    private Vector3 direction;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction.normalized;
        rb.velocity = this.direction * speed;
    }

    //private void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.CompareTag("Suelo"))
    //    {
    //        Destroy(gameObject);

    //    }

    //    if (collision.gameObject.CompareTag("Bacija"))
    //    {
    //        Destroy(gameObject);
    //    }

    //}
}
