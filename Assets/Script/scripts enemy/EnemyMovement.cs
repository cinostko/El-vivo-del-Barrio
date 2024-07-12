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
    [SerializeField] private GameObject VFXDetection;



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
        VFXDetection.SetActive(false);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }
    private void Movimiento()
    {
        float distancia = Vector2.Distance(objetivoTransform.position, transform.position); // distancia dara flloat

        Vector2 direccion = (objetivoTransform.position - transform.position).normalized;
        SetAnimation(direccion);


        if (distancia < seguimientoDistancia && distancia > detenerDistancia)
        {

            //direccion -= direccion.normalized;
            //direccion = direccion.normalized;
            rb2d.velocity = direccion * speed;
            VFXDetection.SetActive(true);
            Invoke("DetenerVFX", 1f);
            animator.SetBool("isMoving", true);
            //isMoving = direccion != Vector2.zero;
            //if (isMoving)
            //{

            //}

        }
        //else if (Vector2.Distance(objetivoTransform.position, transform.position) > detenerDistancia &&  enemyShoot.municion > 0)
        //{
        //    rb2d.velocity = Vector2.zero;
        //}
        //else if (Vector2.Distance(objetivoTransform.position, transform.position) < seguimientoDistancia && enemyShoot.municion <= 0 && Vector2.Distance(objetivoTransform.position, transform.position) > ataqueMelee)
        //{

        //    Vector2 direccion = objetivoTransform.position - transform.position;
        //    direccion -= direccion.normalized;
        //    direccion = direccion.normalized;
        //    rb2d.velocity = direccion * speed;

        //}
        //else if (Vector2.Distance(objetivoTransform.position, transform.position) > ataqueMelee)

        else
        {
            rb2d.velocity = Vector2.zero;
            animator.SetBool("isMoving", false);
        }

    }

    void SetAnimation(Vector2 direccion)
    {
        if (direccion.x != 0) transform.localScale = new Vector3(direccion.x > 0 ? 1 : -1, 1, 1);
        animator.SetFloat("X", direccion.x);
        animator.SetFloat("Y", direccion.y);

    }

    void DetenerVFX()
    {
        VFXDetection.SetActive(false);
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
        animator.SetBool("isMoving", true);
        float timer = 0;
        while (timer <= TiempoAlejandose)
        {
            if (objetivoTransform != null)
            {
                Vector2 direccion = objetivoTransform.position - transform.position;
                direccion -= direccion.normalized;
                direccion = direccion.normalized;
                rb2d.velocity = -direccion * speed;
                SetAnimation(-direccion);
                
            }
            timer += Time.deltaTime;
            yield return null;
        }

        animator.SetBool("isMoving", false);
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
