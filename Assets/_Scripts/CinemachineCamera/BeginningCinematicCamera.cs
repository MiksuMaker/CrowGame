using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BeginningCinematicCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera crowCam1;

    public void Start()
    {
        StartCoroutine(CinematicCameraEvent());

    }

    private IEnumerator CinematicCameraEvent()
    {
        yield return new WaitForSeconds(1f);
        crowCam1.m_Priority = 11;
        yield return new WaitForSeconds(3f);
        crowCam1.m_Priority = 1;
    }

}
