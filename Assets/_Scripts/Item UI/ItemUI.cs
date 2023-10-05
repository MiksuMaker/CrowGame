using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private GameObject pickUpLeft;
    [SerializeField] private GameObject pickUpRight;    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wing"))
        {
            pickUpLeft.SetActive(true);
            pickUpRight.SetActive(true);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("wing"))
        {
            pickUpLeft.SetActive(false);
            pickUpRight.SetActive(false);
        }
    }
}
