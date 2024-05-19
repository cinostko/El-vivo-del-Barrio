using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    [SerializeField] private int life;
    public void CambioVida(int valor)
    {
        life += valor;

        if (life < 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
