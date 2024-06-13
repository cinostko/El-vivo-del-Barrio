using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class disparo : MonoBehaviour
{
    [SerializeField] private proyectil proyectilprefab;
    [SerializeField] private Transform shootposition;
    [SerializeField] private int municion;
    private Camera cam;
    RageBar rageBar;

    private void Awake()
    {
        shootposition = GetComponent<Transform>();
        rageBar = GameObject.Find("Furia").GetComponent<RageBar>();
    }

    void Start()
    {
        cam = Camera.main;
        UIController.Instance.UpdateMunicion(municion);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
        //transform.up = direction;
        if (Input.GetMouseButtonDown(0) && ( municion > 0 || rageBar.isRaging))
        {

            proyectil proyectile = Instantiate(proyectilprefab, shootposition.position, transform.rotation);
            proyectile.launchProjectile(direction);

            if (!rageBar.isRaging)
            {
                municion -= 1;
            }
        }
        if (municion < 0)
        {
            municion = 0;
        }
        UIController.Instance.UpdateMunicion(municion);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Municion"))
        {
            municion += 1;
            Destroy(collision.gameObject);

        }

        if (collision.CompareTag("Policia"))
        {
            municion += 1;
            Destroy(collision.gameObject);

        }
    }


}
