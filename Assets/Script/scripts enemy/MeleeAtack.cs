using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAtack : MonoBehaviour
{
    [SerializeField] private Transform puntoAtq;
    [SerializeField] private float radioAtq;
    [SerializeField] private LayerMask AtqLayermask;
    private float TiempoAtq;
    [SerializeField] private float DelayAtq;


    void Ataque()
    {
        TiempoAtq += Time.deltaTime;

        if (TiempoAtq > DelayAtq)
        {

            //EXPLICACION DE ESTA PARTE
            Collider2D collider = Physics2D.OverlapCircle(puntoAtq.position, radioAtq, AtqLayermask); // CREA UN AREA CIRCULAR Y DETECTA QUE OBJETAS HAY DENTRO DEL AREA DE LA MISMA MÁSCARA 
            if(collider != null) // SI ENCUENTRA ALGO CON COLLIDER
            {
                if (collider.gameObject.GetComponent<PlayerLife>() != null) //PREGUNTA SI TIENE EL COMPonENETE 
                {
                    collider.gameObject.GetComponent<PlayerLife>().CambioVida(-1);
                }
            }

            TiempoAtq = 0;
        }



    }

    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(puntoAtq.position, radioAtq);
    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ataque();
    }
}
