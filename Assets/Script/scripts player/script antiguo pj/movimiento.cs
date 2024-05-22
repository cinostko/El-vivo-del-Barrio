using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    transform.position += new Vector3(0, 1f, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    transform.position += new Vector3(0,-1f, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    transform.position +=new Vector3(-1f,0,0);
        //}
        //if(Input.GetKeyDown(KeyCode.D)) 
        //{
        //    transform.position += new Vector3(1f, 0, 0);
        // }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0) * Time.deltaTime * velocidad;
    }

}
