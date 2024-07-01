using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    private bool Verificar;
    [SerializeField] Animator animator;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Verificar != true)
        {
            Verificar = true;
            animator.SetTrigger("Activar");
            Time.timeScale = 0;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Verificar == true)
        {
            Verificar = false;
            animator.SetTrigger("Activar");
            Time.timeScale = 1;
        }


    }

    public void BotonPausa()
    {
        Time.timeScale = 1;
        animator.SetTrigger("Activar");
    }
}
