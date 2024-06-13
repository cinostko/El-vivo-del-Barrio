using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RageBar : MonoBehaviour
{
    [SerializeField] private Image rageFillImage; //Imagen que representa la barra de furia
    private float rageDuration = 10f; // Duracion de la Furia en segundos
    private float rageTimeRemaining;
    public bool isRaging = false;

    void Update()
    {
        if (isRaging)
        {
            rageTimeRemaining -= Time.deltaTime;
            rageFillImage.fillAmount = rageTimeRemaining / rageDuration;

            if (rageTimeRemaining <= 0)
            {
                StopRage();
            }
        }
    }

    public void StartRage()
    {
        isRaging = true;
        rageTimeRemaining = rageDuration;
        rageFillImage.gameObject.SetActive(true);
    }

    public void StopRage()
    {
        isRaging = false;
        rageFillImage.gameObject.SetActive(false);
    }
}
