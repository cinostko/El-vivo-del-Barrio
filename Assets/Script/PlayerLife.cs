using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private int maxLife;

    private void Start()
    {
        //PREGUNTAR COMO ESTA ESTATICA ESTA SIENDO INVOCADA
        UIController.Instance.UpdateLifeText(life);
        UIController.Instance.UpdateLifeBar(life, maxLife);
    }


    public void CambioVida(int valor)
    {
        life += valor;

        if (life < 0)
        {
            life = 0;
        }
        else if (life > maxLife)
        {
            life = maxLife;
        }
                        
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mostrito"))
        {
            Destroy(collision.gameObject);
            CambioVida(2);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }


    }
}
