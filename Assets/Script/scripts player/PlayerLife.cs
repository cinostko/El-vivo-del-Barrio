using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;
    RageBar ragebar;
    [SerializeField] private Animator animator;
    bool isDead;
    [SerializeField] GameObject EfectoKO;
    [SerializeField] PlayerMovement playermovement;
    [SerializeField] private Animator Derrota;

    private void Awake()
    {
        ragebar = GameObject.Find("Furia").GetComponent<RageBar>();
        animator = GetComponent<Animator>();
        EfectoKO.SetActive(false);
        playermovement= GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        //PREGUNTAR COMO ESTA ESTATICA ESTA SIENDO INVOCADA
        UIController.Instance.UpdateLifeText(life);
        UIController.Instance.UpdateLifeBar(life, maxLife);
    }

   


    public void CambioVida(int valor)
    {
        if (ragebar.isRaging == false)
        {
            life += valor;

            if (life < 0)
            {
                life = 0;
                isDead = true;
                //animator.SetBool("Muerto", true);
                
            }
            else if (life > maxLife)
            {
                life = maxLife;
            }

            UIController.Instance.UpdateLifeBar(life, maxLife);
            UIController.Instance.UpdateLifeText(life);
            //if (life <= 0)
            //{
            //    Destroy(gameObject);
            //}
            if (life <= 0)
            {
                animator.SetTrigger("IsDead");
                EfectoKO.SetActive(true);
                playermovement.enabled = false;
                Derrota.SetTrigger("ActivarDerrota");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mostrito"))
        {
            Destroy(collision.gameObject);
            CambioVida(2);
        }

        if (collision.CompareTag("BalaEnemigo"))
        {
            Destroy(collision.gameObject);
            CambioVida(-1);

        }
    }


    // Update is called once per frame
    void Update()
    {
        //if (life <= 0)
        //{
        //    isDead = true;
        //    animator.SetTrigger("IsDead");
        //    //animator.SetBool("Muerto", true);
        //    //Destroy(gameObject);
        //}


    }
}

