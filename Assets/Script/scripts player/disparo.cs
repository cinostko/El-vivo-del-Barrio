using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    [SerializeField] private proyectil proyectilprefab;
    [SerializeField] private Transform shootposition;
    [SerializeField] private int municion;
    private Camera cam;

    private void Awake()
    {
        shootposition = GetComponent<Transform>();
        
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
        if (Input.GetMouseButtonDown(0) && municion >0)
        {

            proyectil proyectile = Instantiate(proyectilprefab, shootposition.position, transform.rotation);
            proyectile.launchProjectile(direction);
            municion -= 1;
        }
        UIController.Instance.UpdateMunicion(municion);
    }
}
