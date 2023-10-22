using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCrowFly : MonoBehaviour
{

   [SerializeField] private Transform[] crowWaypoints;

   [SerializeField] private float crowSpeed;
   [SerializeField]private float crowRotationSpeed;
    public bool crowFly;

    [SerializeField] private Animator crowAnimator;

    private int crowState;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (crowState == crowWaypoints.Length)
        {
            crowFly = false;
            crowAnimator.SetFloat("Y", 0);
        }

        if (crowFly)
        {
            crowAnimator.SetFloat("Y", 2);
            //Move towards waypoint
            var step = crowSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, crowWaypoints[crowState].position, step);

            //Rotate towards waypoint
            transform.rotation = Quaternion.Slerp(transform.rotation, crowWaypoints[crowState].rotation, crowRotationSpeed * Time.deltaTime);

        }

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flyWaypoint") && crowState < crowWaypoints.Length)
        {
            crowState++;
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("flyStopPoint") && crowState < crowWaypoints.Length)
        {
            crowFly = false;
            crowAnimator.SetFloat("Y", 0);
            crowState++;
            Destroy(other.gameObject);
        }
    }
}
