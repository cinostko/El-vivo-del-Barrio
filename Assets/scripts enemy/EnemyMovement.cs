using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float seguimientoDistancia;
    [SerializeField] private float detenerDistancia;
    private Transform objetivoTransform;
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private EnemyShoot enemyShoot;

    private void Awake()
    {
        objetivoTransform = GameObject.Find("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        enemyShoot = GameObject.Find("Enemy").GetComponent<EnemyShoot>();
    }

    private void Movimiento()
    {
        if (Vector2.Distance(objetivoTransform.position, transform.position) < seguimientoDistancia && Vector2.Distance(objetivoTransform.position, transform.position) > detenerDistancia)
        {
            Vector2 direccion = objetivoTransform.position - transform.position;
            direccion -= direccion.normalized;
            direccion = direccion.normalized;
            rb2d.velocity = direccion * speed;
        }
        else if (Vector2.Distance(objetivoTransform.position, transform.position) > detenerDistancia && enemyShoot.municion > 0)
        {
            rb2d.velocity = Vector2.zero;
        }
        else if (Vector2.Distance(objetivoTransform.position, transform.position) < seguimientoDistancia && enemyShoot.municion <= 0)
        {

            Vector2 direccion = objetivoTransform.position - transform.position;
            direccion -= direccion.normalized;
            direccion = direccion.normalized;
            rb2d.velocity = direccion * speed;

        }

        else
        {
            rb2d.velocity = Vector2.zero;
        }

    }


    // Update is called once per frame
    void Update()
    {
        enemyShoot = GameObject.Find("Enemy").GetComponent<EnemyShoot>();
        if (objetivoTransform == null) return;
       

        Movimiento();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, seguimientoDistancia);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detenerDistancia);



    }
}
