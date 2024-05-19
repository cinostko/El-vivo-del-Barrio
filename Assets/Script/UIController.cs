using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    [SerializeField] private TextMeshProUGUI lifetext;
    [SerializeField] private Image lifeBarImage;

    public static UIController Instance //PREGUNTAR SOBRE LA PROPIEDAD Y ESTATICO. 
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }


    public void UpdateLifeText(int value)
    {
        lifetext.text = $"Vida: {value}";
        
    }

    public void UpdateLifeBar(float life, float maxLife)
    {
        lifeBarImage.fillAmount = life / maxLife;
    }



    // Start is called before the first frame update
    void Start()
    {
        






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
