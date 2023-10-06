using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinematicCameraTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinematicCam;

    [SerializeField] private float waitCinematicChange;
    [SerializeField] private float cameraChangeLenght;
    [SerializeField] private GameObject friendCrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CinematicCameraEvent());
            
        }
    }

    private IEnumerator CinematicCameraEvent()
    {
        yield return new WaitForSeconds(waitCinematicChange);
        cinematicCam.m_Priority = 11;
        yield return new WaitForSeconds(cameraChangeLenght);
        cinematicCam.m_Priority = 1;
        yield return new WaitForSeconds(2);
        friendCrow.GetComponent<FriendCrowFly>().crowFly = true;
        Destroy (this.gameObject);  
    }
}
