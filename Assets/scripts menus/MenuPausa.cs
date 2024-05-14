using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonpausa;
    [SerializeField] private GameObject menupausa;
    private bool juegoPausado = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                reanudar();
            }
            else
            {
                pausa();
            }

        }
    }
    public void pausa()
    {
        Time.timeScale = 0f;
        botonpausa.SetActive(false);
        menupausa.SetActive(true);
    }

    public void reanudar()
    {
        Time.timeScale = 1f;
        botonpausa.SetActive(true);
        menupausa.SetActive(false);
    }
    public void reiniciar()
    {
        Time .timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void cerrar()
    {
        Application.Quit();
    }
    
}
