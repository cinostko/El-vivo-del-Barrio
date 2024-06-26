using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenaDelay : MonoBehaviour
{
    [SerializeField] private int delay;
    [SerializeField] private string EscenaNombre;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CambioEscena", delay);
    }

    private void CambioEscena()
    {
        SceneManager.LoadScene(EscenaNombre);   
    }
    

}
