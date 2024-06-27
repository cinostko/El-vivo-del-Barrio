using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo : MonoBehaviour
{
    public float MaxTime;
    float currentTime;
    PlayerLife playerLife;


    private void Awake()
    {
        
        playerLife=GameObject.Find("Player").GetComponent<PlayerLife>();

    }
    private void Start()
    {


        currentTime = MaxTime;
        //UIController.Instance.TiempoContador(MaxTime);

    }


    private void Update()
    {
        currentTime -= Time.deltaTime;
        int t = (int)currentTime;
        int minutos = t / 60;
        int segundos = t % 60;
        
        UIController.Instance.TiempoContador(t, minutos, segundos);

        if (currentTime <= 0)
        {
            playerLife.CambioVida(-100);
            currentTime = 0;
        }



    }
}
