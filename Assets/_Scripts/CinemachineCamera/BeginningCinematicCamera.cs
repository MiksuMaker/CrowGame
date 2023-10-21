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
        yield return new WaitForSeconds(1f);
        friendCrow.GetComponent<FriendCrowFly>().crowFly = true;
        
    }

}
