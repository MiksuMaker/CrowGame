using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BeginningCinematicCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera crowCam1;
    [SerializeField] private GameObject friendCrow;

    public void Start()
    {
        StartCoroutine(CinematicCameraEvent());

    }

    private IEnumerator CinematicCameraEvent()
    {
        crowCam1.m_Priority = 11;
        yield return new WaitForSeconds(1.5f);
        friendCrow.GetComponent<FriendCrowFly>().crowFly = true;
        yield return new WaitForSeconds(0.5f);
        crowCam1.m_Follow = friendCrow.transform;
        yield return new WaitForSeconds(2f);
        crowCam1.m_Priority = 0;

    }

}
