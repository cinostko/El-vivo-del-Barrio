using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
=======
//public class disparo : MonoBehaviour
//{
//    [SerializeField] private proyectil projectilprefab;
//    [SerializeField] private Transform shootposition;
//    private Camera cam;
//    void Start()
//    {
//        cam = Camera.main;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector2 mouseWorldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
//        Vector2 direction = mouseWorldPoint - (Vector2)transform.position;
//        transform.up = direction;
//        if (Input.GetMouseButtonDown(0))
//        {

//            proyectil proyectile = Instantiate(projectilprefab, shootposition.position, transform.rotation);
//            proyectile.launchProjectile(transform.up);
//        }

//    }
//}
>>>>>>> 72d73263a4139271480a836978e9be4ef7ec14b0
