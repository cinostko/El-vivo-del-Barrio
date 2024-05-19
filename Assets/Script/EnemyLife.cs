using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int life;

    void VidaEnemigo(int valor)
    {
        life += valor;

        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
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
