using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float seguimientoDistancia;
    [SerializeField] private float detenerDistancia;
    [SerializeField] private float ataqueMelee;
    private Transform objetivoTransform;
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private EnemyShoot enemyShoot;
    private EstadoEnemigo EstadoActivo;
    [SerializeField] private float TiempoAlejandose;
    private Animator animator;
    private bool isMoving;



    public enum EstadoEnemigo
    {
        Siguiendo,
        Alejandose
    }

    private void Awake()
    {
        EstadoActivo = EstadoEnemigo.Siguiendo;
        objetivoTransform = GameObject.Find("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        enemyShoot = GameObject.Find("Enemy").GetComponent<EnemyShoot>();
        animator = GetComponent<Animator>();
    }

    private void Movimiento()
    {
        if (Vector2.Distance(objetivoTransform.position, transform.position) < seguimientoDistancia && Vector2.Distance(objetivoTransform.position, transform.position) > detenerDistancia)
        {
            Vector2 direccion = objetivoTransform.position - transform.position;
            direccion -= direccion.normalized;
            direccion = direccion.normalized;
            rb2d.velocity = direccion * speed;
            isMoving = direccion != Vector2.zero;
            if (isMoving)
            {

                animator.SetFloat("X", direccion.x);
                animator.SetFloat("Y", direccion.y);
            }

        }
        //else if (Vector2.Distance(objetivoTransform.position, transform.position) > detenerDistancia &&  enemyShoot.municion > 0)
        //{
        //    rb2d.velocity = Vector2.zero;
        //}
        else if (Vector2.Distance(objetivoTransform.position, transform.position) < seguimientoDistancia && enemyShoot.municion <= 0 && Vector2.Distance(objetivoTransform.position, transform.position) > ataqueMelee)
        {

            Vector2 direccion = objetivoTransform.position - transform.position;
            direccion -= direccion.normalized;
            direccion = direccion.normalized;
            rb2d.velocity = direccion * speed;

        }
        //else if (Vector2.Distance(objetivoTransform.position, transform.position) > ataqueMelee)

        else
        {
            rb2d.velocity = Vector2.zero;
        }
       
    }


    // Update is called once per frame
    void Update()
    {
       
        switch (EstadoActivo)
        {
            case EstadoEnemigo.Siguiendo:
                Movimiento();
                    break;
            case EstadoEnemigo.Alejandose:
                break;
        }

        if (objetivoTransform== null) return;
       
    }

    public void Alejado()
    {
        if (EstadoActivo == EstadoEnemigo.Siguiendo)
        {
            EstadoActivo = EstadoEnemigo.Alejandose;
            StartCoroutine(Alejandose());
        }
    }

    IEnumerator Alejandose()
    {
        float timer = 0;
        while (timer <= TiempoAlejandose)
        {
            if (objetivoTransform != null)
            {
                Vector2 direccion = objetivoTransform.position - transform.position;
                direccion -= direccion.normalized;
                direccion = direccion.normalized;
                rb2d.velocity = -direccion * speed;
            }
            timer += Time.deltaTime;
            yield return null;
        }

        EstadoActivo = EstadoEnemigo.Siguiendo;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, seguimientoDistancia);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detenerDistancia);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, ataqueMelee);



    }
    
    

}
