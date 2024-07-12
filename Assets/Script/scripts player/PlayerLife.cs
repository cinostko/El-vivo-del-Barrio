using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;
    RageBar ragebar;
    [SerializeField] private Animator animator;
    //bool isDead;
    [SerializeField] GameObject EfectoKO;
    [SerializeField] PlayerMovement playermovement;
    [SerializeField] private Animator Derrota;
    [SerializeField] private Rigidbody2D rb2;
    [SerializeField] private GameObject EfectoRecoger;

    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField] private Gradient _gradient;
    private SpriteRenderer _render;
    private float time = -1;

    private void Awake()
    {
        ragebar = GameObject.Find("Furia").GetComponent<RageBar>();
        animator = GetComponent<Animator>();
        EfectoKO.SetActive(false);
        playermovement= GetComponent<PlayerMovement>();
        rb2 = GetComponent<Rigidbody2D>();
        EfectoRecoger.SetActive(false); 
        _render = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //PREGUNTAR COMO ESTA ESTATICA ESTA SIENDO INVOCADA
        //UIController.Instance.UpdateLifeText(life);
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
                //isDead = true;
                //animator.SetBool("Muerto", true);
                
            }
            else if (life > maxLife)
            {
                life = maxLife;
            }

            UIController.Instance.UpdateLifeBar(life, maxLife);
            //UIController.Instance.UpdateLifeText(life);
            //if (life <= 0)
            //{
            //    Destroy(gameObject);
            //}
            if (life <= 0)
            {
                animator.SetTrigger("IsDead");
                EfectoKO.SetActive(true);
                playermovement.enabled = false;
                rb2.bodyType = RigidbodyType2D.Static;
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
            EfectoRecoger.SetActive(true);
            Invoke("ApagarRecoger", 0.5f);
        }

        if (collision.CompareTag("BalaEnemigo"))
        {
            Destroy(collision.gameObject);
            CambioVida(-1);
            time = 0;

        }
    }

    void ApagarRecoger()
    {
        EfectoRecoger.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        if (time < 0) return;
        time = Mathf.Clamp01(time += Time.deltaTime * _speed);
        _render.color = _gradient.Evaluate(time);
        if (time == 1) time = -1;

    }
}

