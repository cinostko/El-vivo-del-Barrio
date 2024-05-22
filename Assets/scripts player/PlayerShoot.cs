using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] private proyectil projectilprefab;
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

            proyectil proyectile = Instantiate(projectilprefab, shootposition.position, transform.rotation);
            proyectile.launchProjectile(transform.up);
        }

    }
}
