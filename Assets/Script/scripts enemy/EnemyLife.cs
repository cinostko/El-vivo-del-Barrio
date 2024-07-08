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


    private void Awake()
    {

        EfectoKO.SetActive(false);
        enemymovement = GetComponent<EnemyMovement>();
        rb2 = GetComponent<Rigidbody2D>();
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
            //rb2.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("IsDead");            
            EfectoKO.SetActive(true);

            //Destroy(gameObject);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            VidaEnemigo(-1);
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
