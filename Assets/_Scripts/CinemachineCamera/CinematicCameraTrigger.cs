using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinematicCameraTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinematicCam;

    [SerializeField] private float waitStartCinematicChange;
    [SerializeField] private float waitEndCinematicChange;
    [SerializeField] private float cameraChangeLenght;
    [SerializeField] private GameObject friendCrow;

    LevelEnd levelEnd;

    private void Start()
    {
        levelEnd = FindObjectOfType<LevelEnd>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CinematicCameraEvent());
            
        }
    }

    private IEnumerator CinematicCameraEvent()
    {
        friendCrow.GetComponent<FriendCrowFly>().crowFly = true;
        yield return new WaitForSeconds(waitStartCinematicChange);
        cinematicCam.m_Priority = 11;
        yield return new WaitForSeconds(waitEndCinematicChange);
        cinematicCam.m_Priority = 1;
        levelEnd.levelState++;
        Destroy (this.gameObject);  
    }
}
