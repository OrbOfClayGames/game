using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;
    //public Transform followTarget;


    public void SetFollowTarget()
    {
        vCam.m_Follow = PlayerController.instance.transform;
        //vCam.m_Follow = followTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetFollowTarget();
    }

    // Update is called once per frame
    void Update()
    {
        //SetFollowTarget();
    }
}
