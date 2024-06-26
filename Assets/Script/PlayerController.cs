using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RageBar rageBar; // Referencia al script de la barra de furia
    //private bool hasBeer = false;
    [SerializeField] private int ContadorCerveza = 0;

    void Update()
    {
        if (ContadorCerveza >0 && Input.GetKeyDown(KeyCode.C))
        {
            UseBeer();
        }
    }

    public void PickupBeer()
    {
        //hasBeer = true;
        if (ContadorCerveza < 1)
        {
            ContadorCerveza++;
            // Aqui podrias añadir logica para mostrar que el jugador tiene una cerveza
            Debug.Log("Cerveza recogida");

        }
    }

    public void UseBeer()
    {
        if (ContadorCerveza>0)
        {
            //hasBeer = false;
            ContadorCerveza--;
            rageBar.StartRage();
            // Aqui podrias añadir logica para mostrar que el jugador ha usado la cerveza
            Debug.Log("Cerveza usada. Furia Activada.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Beer") && ContadorCerveza < 1)
        {
            PickupBeer();
            Destroy(other.gameObject);

           
        }
    }




}
