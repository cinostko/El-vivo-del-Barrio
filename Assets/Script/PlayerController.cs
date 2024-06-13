using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RageBar rageBar; // Referencia al script de la barra de furia
    private bool hasBeer = false;

    void Update()
    {
        if (hasBeer && Input.GetKeyDown(KeyCode.C))
        {
            UseBeer();
        }
    }

    public void PickupBeer()
    {
        hasBeer = true;
        // Aqui podrias añadir logica para mostrar que el jugador tiene una cerveza
        Debug.Log("Cerveza recogida");
    }

    public void UseBeer()
    {
        if (hasBeer)
        {
            hasBeer = false;
            rageBar.StartRage();
            // Aqui podrias añadir logica para mostrar que el jugador ha usado la cerveza
            Debug.Log("Cerveza usada. Furia Activada.");
        }
    }
}
