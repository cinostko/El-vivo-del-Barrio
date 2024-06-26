using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    [SerializeField] private float speed;

    private float destroyDelay = 5f;
    private Rigidbody2D projectilrb;

    private void Awake()
    {
        projectilrb = GetComponent<Rigidbody2D>();
    }

    public void launchProjectile(Vector2 direction)
    {
        projectilrb.velocity = direction * speed;
        Destroy(gameObject, destroyDelay);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Muro"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muro"))
        {
            Destroy(gameObject);
        }
    }


    




}
