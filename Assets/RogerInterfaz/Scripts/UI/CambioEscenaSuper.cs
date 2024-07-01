using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaSuper : MonoBehaviour
{
    [SerializeField] private int delay;
    [SerializeField] private string EscenaNombre;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void CambioEscena()
    {
        Invoke("Tiempoescena", delay);
    }

    private void Tiempoescena()
    {
        SceneManager.LoadScene(EscenaNombre);

    }

    public void CambioEscenaGameplay()
    {
        Invoke("GameplayActivo", delay);
        Time.timeScale = 1;

    }

    private void GameplayActivo()
    {
        
        SceneManager.LoadScene(EscenaNombre);
    }

    public void ReintentarAccion()
    {
        Invoke("ReintentarFuncion",  delay);
    }

    private void ReintentarFuncion()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
