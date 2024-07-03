using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasaralNivel2 : MonoBehaviour
{
    [SerializeField] private string EscenaNombre;
    [SerializeField] private int delay;
    [SerializeField] private Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CambioDeEscena"))
        {
            Invoke("Tiempoescena", delay);
            animator.SetTrigger("NuevoJuego");
        }
    }
    private void Tiempoescena()
    {
        SceneManager.LoadScene(EscenaNombre);
    }

}
