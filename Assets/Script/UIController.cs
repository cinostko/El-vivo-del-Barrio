using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    private static UIController instance2;
    [SerializeField] private TextMeshProUGUI lifetext;
    [SerializeField] private TextMeshProUGUI municiontext;
    [SerializeField] private Image lifeBarImage;
    [SerializeField] private Image furiaBarImage;

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

    public void UpdateFuriaBar(float furia, float maxFuria)
    {
        furiaBarImage.fillAmount = furia / maxFuria;
    }

    public void UpdateMunicion(int value)
    {
        municiontext.text = $"Municion : {value}";
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
