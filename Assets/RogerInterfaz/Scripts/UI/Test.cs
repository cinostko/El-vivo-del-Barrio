using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] RawImage RawImage;
    [SerializeField] float Velocity;
    

    private void Update()
    {
        Rect rectPosition = RawImage.uvRect;
        rectPosition.x += Time.deltaTime * Velocity;
        RawImage.uvRect = rectPosition;
    }
}
