using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altf4 : MonoBehaviour
{
    public void Activador()
    {
        Debug.Log("SeActivoFuncionCerrar");
        Invoke("cerrarjuego", 3);
    }
    private void cerrarjuego()
    {
        Application.Quit();
        Debug.Log("Cerroeljuego");
    }
}
