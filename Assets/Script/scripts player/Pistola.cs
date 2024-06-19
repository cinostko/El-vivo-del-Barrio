using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    [SerializeField] private float Rango;
    [SerializeField] private LayerMask CapaEnemigo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AtaqueEspecial();
    }

    void AtaqueEspecial()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, Rango);
    }
}
