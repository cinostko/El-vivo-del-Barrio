using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraOnAim : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera CamaraApuntado;
    private CinemachineTransposer transposer;
    private Camera Cam;

    private void Awake()
    {
        Cam = Camera.main;
        transposer = CamaraApuntado.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Update()
    {
        Vector3 target = new Vector3(0, 0, -10);

        if (Input.GetMouseButton(1))
        {
            Vector3 WorldPos = Cam.ScreenToWorldPoint(Input.mousePosition);
            target = (transform.position - WorldPos).normalized * -5;
            target.z = -10;
        }

        transposer.m_FollowOffset = Vector3.Lerp(transposer.m_FollowOffset, target, Time.deltaTime * 10);
    }
}
