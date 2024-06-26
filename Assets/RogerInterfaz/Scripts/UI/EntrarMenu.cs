using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntrarMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animator2;
    
    private void Update()
    {
        if (animator != null)
        {
            if (Input.anyKeyDown)
            {
                
                if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2))
                {
                  animator.SetTrigger("SelectedTrigger");
                    Invoke("Cambio", 1);
                }
            }
        }
    }

    private void Cambio()
    {
        animator2.SetTrigger("Test");
    }

}
