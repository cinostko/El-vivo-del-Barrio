using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuria : MonoBehaviour
{
    [SerializeField] private int furia;
    [SerializeField] private int maxFuria;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CambioFuria(int valor)
    {
        furia += valor;

        if (furia < 0)
        {
            furia = 0;
        }
        else if (furia > maxFuria)
        {
            furia = maxFuria;
        }

        UIController.Instance.UpdateFuriaBar(furia, maxFuria);
        
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
