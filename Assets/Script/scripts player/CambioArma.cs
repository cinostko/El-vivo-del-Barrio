using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioArma : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;
    private int index = -1;
    [SerializeField]private Image CambiodeArma;

    // Start is called before the first frame update
    void Start()
    {
        Change(index);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Q)) return;

        index++;
        if (index >= armas.Length) index = 0;
        Change(index);
        
    }

    private void Change(int index)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(i == index);

        }

        
    }
    
        
}

