using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    [SerializeField] private proyectil proyectilprefab;
    [SerializeField] private Transform shootposition;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
        transform.up = direction;
        if (Input.GetMouseButtonDown(0))
        {

            proyectil proyectile = Instantiate(proyectilprefab, shootposition.position, transform.rotation);
            proyectile.launchProjectile(transform.up);
        }
    }
}
