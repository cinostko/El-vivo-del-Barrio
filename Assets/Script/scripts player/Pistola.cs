using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] private float Rango;
    [SerializeField] private LayerMask CapaEnemigo;
    [SerializeField] private float timerShoot;
    [SerializeField] private Animator animator;
    [SerializeField] PlayerMovement playermovement;
    [SerializeField] GameObject EfectoPistola;
    [SerializeField] Rigidbody2D rb2;

    //[SerializeField] private int municion;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playermovement = GetComponent<PlayerMovement>();
        EfectoPistola.SetActive(false);
        rb2 = GetComponent<Rigidbody2D>();

    }


    // Start is called before the first frame update
    void Start()
    {
        timerShoot = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        AtaqueEspecial();
       
        Timer();
        int t = (int)timerShoot;
        int minutos = t / 60;
        int segundos = t % 60;
        UIController.Instance.ContadorPistolaText(t, minutos, segundos);


    }

    void Timer()
    {
        timerShoot -= Time.deltaTime;
        if (timerShoot < 0)
        {
            timerShoot = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && timerShoot<=0)
        {
            timerShoot = 60;
        }
    }

    void AtaqueEspecial()
    {
        if (timerShoot <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playermovement.enabled = false;
                rb2.bodyType = RigidbodyType2D.Static;
                animator.SetBool("IsShooting", true);
                Invoke("ActivarVFX", 0.4f);
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Rango, CapaEnemigo);
                foreach (Collider2D collider in colliders)
                {
                    if (collider.gameObject.GetComponent<EnemyMovement>() != null)
                    {
                        collider.gameObject.GetComponent<EnemyMovement>().Alejado();
                    }
                }
                

            }
        }
        if (timerShoot > 0 && timerShoot < 59)
        {
            animator.SetBool("IsShooting", false);
            EfectoPistola.SetActive(false);
            playermovement.enabled = true;
            rb2.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void ActivarVFX()
    {
        EfectoPistola.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, Rango);
    }
}
