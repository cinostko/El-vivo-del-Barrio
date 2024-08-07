using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Vector2 direccion;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    [SerializeField] private int VelocidaRotacion;
    float z;
    [SerializeField] private ParticleSystem ParticleSystem;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
            

    }

    public void Direccion(Vector2 direccion)
    {
        this.direccion = direccion;
    }

    void Movimiento()
    {
        rb2d.velocity = direccion * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Muro") || collision.CompareTag("Player"))
        {
            Instantiate(ParticleSystem,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        z += Time.deltaTime * VelocidaRotacion;
        transform.rotation = Quaternion.Euler(0, 0, z);
        Movimiento();
    }
}
