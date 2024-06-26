using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    private bool Verificar;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Verificar != true)
        {   
            Verificar = true;
            Time.timeScale = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Verificar == true)
        {
            Verificar = false;
            Time.timeScale = 1;
        }
    }

}
