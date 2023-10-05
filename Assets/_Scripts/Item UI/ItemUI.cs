using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private GameObject pickUpLeft;
    [SerializeField] private GameObject pickUpRight;    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("wing"))
        {
            pickUpLeft.SetActive(true);
            pickUpRight.SetActive(true);


        }
        else
        {
            pickUpLeft.SetActive(false);
            pickUpRight.SetActive(false);
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
