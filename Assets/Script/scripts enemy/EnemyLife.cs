using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life;
    [SerializeField] GameObject EfectoKO;
    [SerializeField] EnemyMovement enemymovement;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb2;
    [SerializeField] GameObject VFXDetection;

    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField] private Gradient _gradient;
    private SpriteRenderer _render;
    private float time = -1;

    private void Awake()
    {

        EfectoKO.SetActive(false);
        enemymovement = GetComponent<EnemyMovement>();
        rb2 = GetComponent<Rigidbody2D>();
        _render = GetComponent<SpriteRenderer>();
    }

    void VidaEnemigo(int valor)
    {
        life += valor;
        if (life >0)
        {
            enemymovement.enabled = true;
        }
        if(life <= 0)
        {

            life = 0;
            enemymovement.enabled = false;
            rb2.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("IsDead");            
            EfectoKO.SetActive(true);
            Destroy(VFXDetection);

            //Destroy(gameObject);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            VidaEnemigo(-1);
            time = 0;
        }
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
