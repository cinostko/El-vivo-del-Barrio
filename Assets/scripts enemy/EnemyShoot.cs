using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float DistanciaDisparo;
    public int municion;

    private Transform objetivoTransform;
    private float shootTimer;

    private void Awake()
    {
        objetivoTransform = GameObject.Find("Player").transform;
    }


    void Disparo()
    {
        if (Vector2.Distance(objetivoTransform.position, transform.position) < DistanciaDisparo)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= 0.5f && municion >= 1)
            {
                Vector2 direccion = objetivoTransform.position - transform.position;
                direccion = direccion.normalized;
                GameObject obj = Instantiate(bulletPrefab);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletMovement>().Direccion(direccion);
                shootTimer = 0;
                municion -= 1;
            }

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, DistanciaDisparo);

    }


    // Update is called once per frame
    void Update()
    {
        Disparo();
    }
}
